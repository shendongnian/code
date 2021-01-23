    Console.WriteLine("Put in the price of the product");
    string input = Console.ReadLine();
    decimal sum;
    if (!Decimal.TryParse(input, out sum))
    {
        Console.WriteLine("Decimal number cannot be parsed from your input.");
        return;
    }
    if (sum <= 100)
        Console.WriteLine("Your final price is {0:0:00}", sum * 0.90M);
