    static void Main(string[] args)
    {
        string price, discount;
        decimal discountedPrice, savedAmount;
        bool startAgain = true;
        string line;
       
        // Loop again every time the startAgain flag is true.
        while (startAgain)
        {
            //Receiving the price as input
            Console.WriteLine("Please enter the price of the item.");
            price = Console.ReadLine();
            decimal numPrice = decimal.Parse(price);
        
            //Receiving the discount as input
            Console.WriteLine("Please enter the discount that you wish to apply");
            discount = Console.ReadLine();
            //Receiving discount from input, divide by 100 to convert to percentile
            decimal numDiscount = decimal.Parse(discount) / 100;
        
            //Calculate the discounted price with price - (price * discount)
            discountedPrice = numPrice - (numPrice * numDiscount);
            //Calculate the amount of money they saved
            savedAmount = numPrice - discountedPrice;
            Console.WriteLine("The discounted price of this item is: ${0}\nYou saved: ${1}", discountedPrice, savedAmount);
            Console.ReadLine();
            // Ask if the user wants to submit another price.
            Console.WriteLine("Would you like to enter another price?");
            // Record the spaceless, lower-case answer.
            line = Console.ReadLine().ToLowerCase().Trim();
            // Set the startAgain flag to true only if the line was "y" or "yes".
            startAgain = line == "y" || line == "yes";
        }
    }
