    public static string ToShortTimeSafe(this TimeSpan timeSpan)
    {
        return new DateTime().Add(timeSpan).ToShortTimeString();
    } 
    public static string ToShortTimeSafe(this TimeSpan? timeSpan)
    {
        return timeSpan == null ? string.Empty : timeSpan.Value.ToShortTimeSafe();
    }
