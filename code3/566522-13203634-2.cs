    static void Main(string[] args)
    {
        const double price = 10;
        int userInputDigit = 0;
        double userCost = 0;
        string line = null;
        while (!string.Equals(line, "q", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Enter a number or press 'q' to exit...");
            line = Console.ReadLine();
    
            if (int.TryParse(line, out userInputDigit))
            {
                if (userInputDigit <= 50)
                {
                    userCost = (price * userInputDigit);
                    Console.WriteLine("You have purchased {0} Widgets at a cost of {1:c0}", userInputDigit, userCost);
                }
                else if ((userInputDigit > 50) && (userInputDigit <= 80))
                {
                    userCost = (price * 50) + ((userInputDigit - 50) * (price - 1));
                    Console.WriteLine("You have purchased {0} Widgets at a cost of {1:c0}", userInputDigit, userCost);
                }
                else if ((userInputDigit > 80) && (userInputDigit <= 100))
                {
                    userCost = (price * 50) + (30 * (price - 1)) + ((userInputDigit - 80) * (price - 2.50));
                    Console.WriteLine("You have purchased {0} Widgets at a cost of {1:c0}", userInputDigit, userCost);
                }
                else
                {
                    Console.WriteLine("Error! Please input a number between 0 and 100");
                }
            }
        }
        return;
    }
