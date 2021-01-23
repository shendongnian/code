    int denom;
    
    try
    {
         denom = 0;
        int x = 5 / denom;
    }
    
    // Catch /0 on all days but Saturday
    
    catch (DivideByZeroException xx) when (DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
    {
         Console.WriteLine(xx);
    }
