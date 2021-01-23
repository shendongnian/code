    string sTemp = "10.12;12.13;15.345";
    var doubles = sTemp.Split(';')
        .Select(s => double.Parse(s, CultureInfo.InvariantCulture));
    var locale = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
    // or var locale = System.Globalization.CultureInfo.CurrentCulture;
    var localeDoubleStrings = doubles.Select(d => d.ToString(locale));
    foreach(string frDoubleStr in localeDoubleStrings)
        Console.WriteLine(frDoubleStr);
