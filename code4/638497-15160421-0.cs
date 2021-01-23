    DateTime now = DateTime.Now;
    dtlist.Sort((d1, d2) =>
    { 
        var dtTrunc1 = new DateTime(now.Year, d1.Month, d1.Day, d1.Hour, d1.Minute, d1.Second, d1.Millisecond);
        var dtTrunc2 = new DateTime(now.Year, d2.Month, d2.Day, d2.Hour, d2.Minute, d2.Second, d2.Millisecond);
        TimeSpan diff1 = dtTrunc1 - now;
        TimeSpan diff2 = dtTrunc2 - now;
        if (diff1.Ticks >= 0 && diff2.Ticks >= 0 || diff1.Ticks < 0 && diff2.Ticks < 0)
            return diff1.Ticks.CompareTo(diff2.Ticks);
        if (diff1.Ticks < 0 && diff2.Ticks >= 0)
            return int.MaxValue;
        else
            return int.MinValue;
    });
