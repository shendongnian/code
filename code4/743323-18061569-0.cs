    private static readonly DateTime UnixEpoch = 
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public static DateTime UnixTimeStampToDateTime(double secondsSinceUnixEpoch)
    {
        return UnixEpoch.AddSeconds(secondsSinceUnixEpoch);
    }
