    public static bool ValidateDate(string date, string format)
    {
        DateTime dateTime;
        return DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
    }
