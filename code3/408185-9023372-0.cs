    // Add appropriate overloads to match TryParse and TryParseExact
    public static DateTime? TryParseNullableDateTime(string text)
    {
        DateTime value;
        return DateTime.TryParse(text, out value) ? value : (DateTime?) null;
    }
