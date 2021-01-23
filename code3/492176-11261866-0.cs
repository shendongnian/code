    var formatInfo = new System.Globalization.NumberFormatInfo()
    {
        CurrencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol,
        CurrencyGroupSeparator = "" // remove the group separator
    };
    Console.WriteLine(2.ToString("C", formatInfo));
    Console.WriteLine(4.ToString("C", formatInfo));
    Console.WriteLine(1000.ToString("C", formatInfo));
