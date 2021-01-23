    DateTime date1 = new DateTime(2008, 8, 29, 19, 27, 15, 18);
    CultureInfo ci = CultureInfo.InvariantCulture;
    Console.WriteLine(date1.ToString("hh:mm:ss.f", ci));
    // Displays 07:27:15.0
    Console.WriteLine(date1.ToString("hh:mm:ss.F", ci));
    // Displays 07:27:15
    Console.WriteLine(date1.ToString("hh:mm:ss.ff", ci));
    // Displays 07:27:15.01
    Console.WriteLine(date1.ToString("hh:mm:ss.FF", ci));
    // Displays 07:27:15.01
    Console.WriteLine(date1.ToString("hh:mm:ss.fff", ci));
    // Displays 07:27:15.018
    Console.WriteLine(date1.ToString("hh:mm:ss.FFF", ci));
    // Displays 07:27:15.018
