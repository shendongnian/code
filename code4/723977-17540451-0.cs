    DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
    Console.WriteLine(date1.ToString("G", DateTimeFormatInfo.InvariantInfo));
    // Displays 04/10/2008 06:30:00
    Console.WriteLine(date1.ToString("G", CultureInfo.CreateSpecificCulture("en-us")));
    // Displays 4/10/2008 6:30:00 AM                        
    Console.WriteLine(date1.ToString("G", CultureInfo.CreateSpecificCulture("nl-BE")));
