    // force the date format to be 12hour like in US
    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    
    DateTime start = DateTime.Parse("1/1/2013 7:00 PM").ToUniversalTime();
    DateTime end = start.AddHours(5); // returns 1/2/2013 12:00:00 AM as it should
    
    Console.WriteLine(end - start); // 05:00:00
    Console.WriteLine((end - start) > TimeSpan.Zero); // True
