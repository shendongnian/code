public static DateTime IndianDateTime(DateTime currentTime)
{
    DateTime cstTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "India Standard Time");
    return cstTime;
}
