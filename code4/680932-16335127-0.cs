    string date = "01/20/2013 02:30PM";
    DateTime dtTime;
    if (DateTime.TryParseExact(date, "MM/dd/yyyy hh:mmtt",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out dtTime))
    {
        Console.WriteLine(dtTime);
    }
