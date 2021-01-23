    public static string FormatDurationSeconds(int seconds)
    {
        var duration = TimeSpan.FromSeconds(seconds);
        string result = "";
        if (duration.TotalHours >= 1)
            result += (int) duration.TotalHours + " Hours, ";
        result += String.Format("{0:%m} Minutes, {0:%s} Seconds", duration);
        return result;
    }
