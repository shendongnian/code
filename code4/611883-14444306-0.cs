    private void SetUserStartTimesUTC()
    {
        DateTime nowUtc = DateTime.UtcNow;
        TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(UserTimeZoneID);
        // User-local values, all with a Kind of Unspecified.
        DateTime now = TimeZoneInfo.ConvertTime(nowUtc, zone);
        DateTime today = nowUser.Date;
        DateTime startOfThisMonth = todayUser.AddDays(1 - today.Day);
        DateTime startOfNextMonth = startOfThisMonth.AddMonths(1);
        // Now convert back to UTC... see note below
        UserStartOfDayUTC = TimeZoneInfo.ConvertTimeToUtc(today, zone);
        UserStartOfMonthUTC = TimeZoneInfo.ConvertTimeToUtc(startOfThisMonth, zone);
        UserEndOfMonthUTC = TimeZoneInfo.ConvertTimeToUtc(startOfNextMonth, zone);
    }
