    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0,
                                                              DateTimeKind.Utc);
    ...
    public static DateTime FromUnixTimestamp(long seconds)
    {
        return UnixEpoch + TimeSpan.FromSeconds(seconds);
    }
