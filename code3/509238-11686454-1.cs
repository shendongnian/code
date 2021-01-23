    DateTime Result = new DateTime();
    string[] dateFormats = new string[]{ "YYYYMMDD", "YYMMDD", /*other formats you might need*/ };
    
    if (dateFormats.Any(format => DateTime.TryParseExact("yourDate", format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Result)))
    { /* Result contains the parsed DateTime and you can use it*/ }
    else 
    { /* DateTime couldn't be parsed for any format you specified */ }
