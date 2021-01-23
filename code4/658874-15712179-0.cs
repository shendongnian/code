    double value = 12345.6789;
    Console.WriteLine(value.ToString("E", CultureInfo.InvariantCulture));
    // Displays 1.234568E+004
    Console.WriteLine(value.ToString("E10", CultureInfo.InvariantCulture));
    // Displays 1.2345678900E+004
    Console.WriteLine(value.ToString("e4", CultureInfo.InvariantCulture));
    // Displays 1.2346e+004
    Console.WriteLine(value.ToString("E", CultureInfo.CreateSpecificCulture("fr-FR")));
    // Displays 1,234568E+004
