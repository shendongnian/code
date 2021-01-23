    public static string ToLocalTimeWithTimeZoneAbbreviation(this DateTime dt)
    {
        DateTime localtime = dt.ToLocalTime();
        string tz = TimeZone.CurrentTimeZone.ToAbbreviation();
        string formattedDate = String.Format("{0:yyyy/MM/dd hh:mm:ss} {1}", localtime, tz);
        return formattedDate;
    }
