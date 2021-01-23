    public static string Hours(decimal d)
    {
        var ts = TimeSpan.FromHours((double)(d + 0.005M));
        return string.Format("{0:0}:{1:00}", (int)ts.TotalHours, ts.Minutes);
    }
