    string myDate = "10-05-2013 08:52:30";
    DateTime date = DateTime.Parse(myDate);
    
    Console.WriteLine(date.ToString("d", new CultureInfo("en-US"))); // 5/10/2013
    Console.WriteLine(date.ToString("d", new CultureInfo("nl-NL"))); // 10-5-2013
    
    Console.WriteLine(date.ToString("f", new CultureInfo("nl-NL"))); // vrijdag 10 mei 2013 08:52
