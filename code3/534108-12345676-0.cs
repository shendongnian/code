    public static bool TryParseDouble(this string text, out double value)
    {
       return double.TryParse(text, NumberStyles.Any,
                              CultureInfo.InvariantCulture, out value);
    }
