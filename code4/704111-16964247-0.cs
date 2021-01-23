    DateTime date1 = new DateTime(2013, 1, 1, 13, 00, 36);
    Console.WriteLine(date1.ToString("T", CultureInfo.CreateSpecificCulture("es-ES")));
    // Outputs 6:30:00
    Console.WriteLine(date1.ToString("U", CultureInfo.CreateSpecificCulture("en-US")));
    // Outputs Tuesday, January 1, 2013 13:00:36 PM 
