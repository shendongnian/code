    public static IEnumerable<DateTime> GetMonths(DateTime start, int numberOfMonths);
    {
        for(int i = 0; i < numberOfMonths; i++)
        {
            start = start.AddMonth(i); 
            yield return start;
        }
    }
    
    foreach(var date in GetMonths(DateTime.Now, 6)
    {
        Console.WriteLine("{0:dd/MM/yy}", date);
    }
