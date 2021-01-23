    public  string DateDiff(DateTime DateTime1, DateTime DateTime2)
    {
        string dateDiff = null;
    
        TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
        TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
        TimeSpan ts = ts1.Subtract(ts2).Duration();
        dateDiff = ts.Days.ToString() + "day"
            + ts.Hours.ToString() + "hours"
            + ts.Minutes.ToString() + "minutest"
            + ts.Seconds.ToString() + "seconds";
    
        return dateDiff;
    }
