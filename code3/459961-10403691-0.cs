    public static string GetTime
    {
        get
        {
            TimeSpan time = sr.Elapsed + timeToAdd;
            // In .NET 4 you could use a custom format string for the TimeSpan
            return string.Format("{0}h {1}m {2}s",
                                 time.Hours, time.Minutes, time.Seconds);
        }
    }
