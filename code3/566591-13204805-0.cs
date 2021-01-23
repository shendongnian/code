    while (true)
    {
        string input = Console.ReadLine();
        decimal sum;
        if (Decimal.TryParse(input, out sum) == true)
        {
            if (sum <= 100)
            {
                decimal totalprice = sum * .90m;
                Console.WriteLine("Your final price is {0:0:00}", totalprice);
                break;  // break out of while
            }
        }
    }
