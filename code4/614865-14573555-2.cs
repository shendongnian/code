    public static void UpdateLastActiveTime()
    {
        var t = Thread.CurrentThread;
        if (!lastActiveTime.ContainsKey(t))
            lastActiveTime.Add(t, DateTime.Now);
        else
            lastActiveTime[t] = DateTime.Now;
    }
    private static Dictionary<Thread, DateTime> lastActiveTime;
