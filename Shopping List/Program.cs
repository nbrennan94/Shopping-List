
using System.Collections;

Dictionary<string, double> brennanSeafood = new Dictionary<string, double>()
{
    {"shrimp",14.30},
    {"salmon",28.00},
    {"scallops",36.50},
    {"sea bass",39.90},
    {"tuna",33.00},
    {"swordfish",32.00},
    {"lobster tails",50.00},
    {"crab legs",75.00},
};

List<string> guestPurchase = new List<string>();

double orderTotal = 0;
bool addMore = true;

Console.WriteLine("Welcome to the Brennan Seafood Stall. Here is a list of the items that are available for you to buy today.");
Console.WriteLine("");
Console.WriteLine("Item\t\tPrice");
Console.WriteLine("=========================");

foreach (KeyValuePair<string,double> item in brennanSeafood)
{
    Console.WriteLine($"{item.Key}   \t ${item.Value}.");
}

while(addMore)
{
    Console.WriteLine("What item would you like to add to your basket?");

    while (true)
    {
        string userChoice = Console.ReadLine().ToLower().Trim();
        brennanSeafood.ContainsKey(userChoice);

        if (brennanSeafood.ContainsKey(userChoice))
        {
            Console.WriteLine($"{userChoice} is available and costs ${brennanSeafood[userChoice]}.");
            guestPurchase.Add(userChoice);
            break;
        }
        else
        {
            Console.WriteLine("Sorry, but that is not available at this time. Please, select an item from the menu.");
            foreach (KeyValuePair<string, double> item in brennanSeafood)
            {
                Console.WriteLine($"{item.Key}   \t ${item.Value}.");
            }
        }
    }

    while (true)
    {
        Console.WriteLine("Would you like to purchase another item? y/n");
        string purchaseAnother = Console.ReadLine().ToLower().Trim();
        if (purchaseAnother == "y")
        {
            break;
        }
        else if (purchaseAnother == "n")
        {
            addMore = false;
            break;
        }
        else
        {
            Console.WriteLine("That is not a valid response. Please enter y or n.");
        }
    }
}

string mostExpensive = guestPurchase[0];
string leastExpensive = guestPurchase[0];

Console.WriteLine($"You ordered the following items: ");
for(int i = 0; i < guestPurchase.Count; i++)
{
    Console.WriteLine($"{guestPurchase[i]}, which costs ${brennanSeafood[guestPurchase[i]]}.");
    orderTotal += brennanSeafood[guestPurchase[i]];

    if (brennanSeafood[guestPurchase[i]] < brennanSeafood[leastExpensive])
    {
        leastExpensive = guestPurchase[i];
    }
    if (brennanSeafood[guestPurchase[i]] > brennanSeafood[mostExpensive])
    {
        mostExpensive = guestPurchase[i]; 
    }
}

Console.WriteLine($"Your total today comes to ${orderTotal}. Your highest purchase was {mostExpensive} for ${brennanSeafood[mostExpensive]}. Your lowest purchase was {leastExpensive} for ${brennanSeafood[leastExpensive]}.");
Console.WriteLine("Enjoy and come again soon!");

Console.ReadKey();



