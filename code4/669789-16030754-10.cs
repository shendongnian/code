    public static TimeSpan? TryGetTimeSpan(this string tsString, string format = null)
    {
        TimeSpan ts;
        bool success;
        if (format == null)
            success = TimeSpan.TryParse(tsString, out ts);
        else
            success = TimeSpan.TryParseExact(tsString, format, null, TimeSpanStyles.None, out ts);
        return success ? (TimeSpan?)ts : (TimeSpan?)null;
    } 
