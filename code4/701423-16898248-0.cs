    decimal result;
    var enUS = new System.Globalization.CultureInfo("en-US");
    var a = decimal.TryParse("$10.00", System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.AllowDecimalPoint , enUS, out result);
    
    Console.WriteLine(enUS);
    Console.WriteLine(a);
    Console.WriteLine(result);
