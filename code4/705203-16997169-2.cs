    private static readonly DateTime UnixEpoch =
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    static long GetMillisecondsSinceUnixEpoch(int year, int month, int day,
                                              int hour, int minute)
    {
        DateTime local = new DateTime(year, month, day, hour, minute, 0,
                                      DateTimeKind.Local);
        DateTime utc = local.ToUniversalTime();
        return (long) (utc - UnixEpoch).TotalMilliseconds;
    }
