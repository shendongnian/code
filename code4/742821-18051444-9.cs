    Console.WriteLine("Invalid Choice");
    
    while(!DateTime.TryParseExact(Date, "MM-dd-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
    {    
        Console.WriteLine("Invalid Date Entered, please format MM-dd-yyyy");
        Date = Console.ReadLine();
    }    
    
