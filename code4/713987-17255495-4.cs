    public object Get(ServerTime request)
    {
        return new ServerTime
        {
            DateTime = DateTimeOffset.Now,
            TimeZoneInfo = TimeZoneInfo.Local,
        };
    }
