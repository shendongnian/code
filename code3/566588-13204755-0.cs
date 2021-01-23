    Console.WriteLine("Put in the price of the product");
    string input = Console.ReadLine();
    decimal sum;
    if (!Decimal.TryParse(input, out sum))
    {
        Console.WriteLine("Decimal number cannot be parsed from your input.");
        return;
    }
