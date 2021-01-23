    public static double GetDouble(string value, double defaultValue)
    {
        double numberToConvert;
    
        if (!double.TryParse(value, System.Globalization.NumberStyles.Any, 
    CultureInfo.CurrentCulture, out numberToConvert) &&
            !double.TryParse(value, System.Globalization.NumberStyles.Any,
    CultureInfo.GetCultureInfo("en-US"), out numberToConvert) &&
            !double.TryParse(value, System.Globalization.NumberStyles.Any,
    CultureInfo.InvariantCulture, out numberToConvert))
        {
            numberToConvert= defaultValue;
        }
    
        return numberToConvert;
    }
