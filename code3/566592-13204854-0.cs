        try
        {
            Console.WriteLine("Put in the price of the product");
            decimal sum;
            // Repeat forever (we'll break the loop once the user enters acceptable data)
            while (true)
            {
                string input = Console.ReadLine();
                // Try to parse the input, if it succeeds, TryParse returns true, and we'll exit the loop to process the data.
                // Otherwise we'll loop to fetch another line of input and try again
                if (decimal.TryParse(input, out sum)) break;
            }
            if (sum <= 100)
            {
                decimal totalprice = sum * .90m;
                Console.WriteLine("Your final price is {0:0:00}", totalprice);
            }
        }
        catch
        {
        }
