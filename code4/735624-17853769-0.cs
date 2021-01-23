    public static int DateTimeToInt(this DateTime theDate)
    {
        int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        return unixTime;
    }
