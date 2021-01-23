    static string TimeSpanToString(TimeSpan source)
    {
        string result = string.Format("{0}:{1}:{2}",
            (int)source.TotalHours,
            source.Minutes,
            source.Seconds);
        return result;
    }
