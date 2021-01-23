    /// <summary>
    /// Converts a timespan value to a string representation.
    /// </summary>
    /// <param name="time_span">the amount of time to convert to words</param>
    /// <param name="whole_seconds">round up the seconds</param>
    /// <returns>4 minutes, 58 seconds, etc</returns>
    /// <remarks>If it can't convert to a string, it returns "Calculating time remaining..."</remarks>
    public string TimespanToWords(TimeSpan time_span, bool whole_seconds = true)
    {
        TimeSpan span;
        string str2 = "";
        if (time_span.Days > 0)
        {
            str2 = str2 + ", " + time_span.Days.ToString() + " days";
            span = new TimeSpan(time_span.Days, 0, 0, 0);
            time_span = time_span.Subtract(span);
        }
        if (time_span.Hours > 0)
        {
            str2 = str2 + ", " + time_span.Hours.ToString() + " hours";
            span = new TimeSpan(0, time_span.Hours, 0, 0);
            time_span = time_span.Subtract(span);
        }
        if (time_span.Minutes > 0)
        {
            str2 = str2 + ", " + time_span.Minutes.ToString() + " minutes";
            span = new TimeSpan(0, 0, time_span.Minutes, 0);
            time_span = time_span.Subtract(span);
        }
        if (whole_seconds)
        {
            if (time_span.Seconds > 0)
            {
                str2 = str2 + ", " + time_span.Seconds.ToString() + " seconds";
            }
        }
        else
        {
            str2 = str2 + ", " + time_span.TotalSeconds.ToString() + " seconds";
        }
        if (str2.Length > 0)
        {
            str2 = str2.Substring(2);
        }
        if (string.IsNullOrEmpty(str2))
        {
            return "Calculating time remaining...";
        }
        return str2;
    }
