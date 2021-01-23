    public static TimeSpan? TryParse(string s)
    {
        TimeSpan time;
        if (TimeSpan.TryParse(s, out time))
           return time;
    
        return null;
    }
