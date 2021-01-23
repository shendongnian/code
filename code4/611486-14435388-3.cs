    private static Dictionary<TimeSpan, string> TimeSpanText = new Dictionary<TimeSpan, string>();
    static Reminders()
    {
        TimeSpanText.Add(TimeSpan.Zero, "None");
        TimeSpanText.Add(TimeSpan.FromMinutes( 5 ), "5 minutes before");
        TimeSpanText.Add(TimeSpan.FromMinutes( 15 ), "15 minutes before");
        TimeSpanText.Add(TimeSpan.FromMinutes( 30 ), "30 minutes before");
        TimeSpanText.Add(TimeSpan.FromHours( 1 ), "1 hour before");
        // ....
    }
    public static string DisplayName(TimeSpan ts)
    {
        string text;
        if (TimeSpanText.TryGetValue(ts, out text))
            return text;
        else
             throw new ArgumentException("Invalid Timespan", "ts");
    }
