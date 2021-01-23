    DateTime a = new DateTime(2009, 2, 8);
    DateTime b = new DateTime(2009, 8, 8);
    
    while ( a < b )
    {
         Console.WriteLine(a.ToShortDateString());
         a = a.AddMonths(1);
    }
