    Console.Write("Enter the sales for Andrea >> ");
    while (!double.TryParse(Console.ReadLine(), out sale))
    {
        Console.WriteLine("Value entered was not a valid number.");
        Console.Write("Enter the sales for Andrea >> ");
    }
    // Once you get here, "sale" will be set appropriately
