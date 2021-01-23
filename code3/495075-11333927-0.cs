    public static DateTime UnreliableDateTimeFromTickCount(int tickCount)
    {
        DateTime now = DateTime.UtcNow;
        DateTime boot = now - TimeSpan.FromMilliseconds(Environment.TickCount);
        return boot + TimeSpan.FromMilliseconds(tickCount);
    }
