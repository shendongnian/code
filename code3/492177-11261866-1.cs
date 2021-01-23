    var formatInfo = (System.Globalization.NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
    formatInfo.CurrencyGroupSeparator = ""; // remove the group separator
    Console.WriteLine(2.ToString("C", formatInfo));
    Console.WriteLine(4.ToString("C", formatInfo));
    Console.WriteLine(1000.ToString("C", formatInfo));
