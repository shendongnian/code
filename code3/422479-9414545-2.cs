    public static DateTime Add(DateTime dt, TimeSpan t)
    {
        while (true)
        {
            dt = Max(dt, dt.Date.AddHours(9));
            DateTime x = Min(dt + t, dt.Date.AddHours(17));
            // Console.WriteLine("{0} -> {1} ({2})", dt, x, x - dt);
            t -= x - dt;
            dt = x;
            if (t == TimeSpan.Zero) { return dt; }
            do { dt = dt.Date.AddDays(1); } while (dt.IsWeekendDay());
        }
    }
