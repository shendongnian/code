    public static void Main()
    { 
        //current date  
        DateTime dt = DateTime.UtcNow.AddHours(6);
        //you can use it custom date  
        var cmYear = new DateTime(dt.Year, dt.Month, dt.Day);
        //here 2 is the day value of the week in a date
        var customDateWeek = cmYear.AddDays(-2); 
        Console.WriteLine(dt);
        Console.WriteLine(cmYear);
        Console.WriteLine("Date: " + customDateWeek);
        Console.WriteLine();  
        Console.ReadKey();
    }
