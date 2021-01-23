    public static string GetCulture(this string value)
    {
        var doubleValue = default(double);
        var germanCultureInfo = new CultureInfo("de-DE");
        var englishCultureInfo = new CultureInfo("en-US");
        if (double.TryParse(value, NumberStyles.AllowDecimalPoint, germanCultureInfo, out doubleValue))
        {
            return "german";
        }
        else if (double.TryParse(value, NumberStyles.AllowDecimalPoint, englishCultureInfo, out doubleValue))
        {
           return "us";
        }
        return string.Empty; ;
    }
