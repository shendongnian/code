    private static readonly DateTime UnixEpochStart = 
                   DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
    public static DateTime ToDateTimeFromEpoch(this long epochTime)
    {
       DateTime result = UnixEpochStart.AddMilliseconds(epochTime);
       return result;
    }
