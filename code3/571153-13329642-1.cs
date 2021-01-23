    public static string FormatDateTimeAsGregorian(DateTime input)
    {
        return input.ToString("yyyy'/'MM'/'dd' 'HH':'mm':'ss",
                              CultureInfo.InvariantCulture);
    }
