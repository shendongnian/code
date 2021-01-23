    public static bool IsDate(string value)
    {
        DateTime date;
        return DateTime.TryParse(value, out date);
    }
