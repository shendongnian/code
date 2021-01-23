    public static void Main(string[] args)
    {
    
        Console.WriteLine(DateTime.ParseExact("22-01-2013 00:00:00", "dd-MM-yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd"));
    
    }
