    double initialCapital = 0;
    double interest = 0;
    int year = 0;
    double capital = 0;
                
    Console.Write("Initial capital: ");
    initialCapital = int.Parse(Console.ReadLine());
    
    Console.Write("Interest: ");
    interest = int.Parse(Console.ReadLine());
    capital = initialCapital;
    
    while (capital < initialCapital * 2)
    {
        capital = capital * (1 + interest / 100);
        year = year + 1;
        Console.WriteLine("Years: " + year);
        Console.WriteLine("Capital: " + capital);
    }
    
    Console.WriteLine("Years: " + year);
    Console.WriteLine("Capital: " + capital);
    
    double exactYears = Math.Log(2) / Math.Log((100 + interest) / 100);
    Console.WriteLine(string.Format("Capital doubled in exactly: {0:0.000} years", exactYears));
