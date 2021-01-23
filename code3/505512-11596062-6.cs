    public static DateTime getNextWeekDay(DateTime date, DayOfWeek dayOfWeek, int weekNum)
    {
        if (weekNum < 1 || weekNum > 4)
            throw new ArgumentException("Number of week must be between 1 and 4.", "weekNum");
        int inWeekNum = date.Date.Day / 7;
        if (inWeekNum >= weekNum)
        {
            var nextMonth = date.AddMonths(1);
            date = new DateTime(nextMonth.Year, nextMonth.Month, 1);
        }
        DateTime currentDate = date;
        int currentWeekNum = 0;
        while (currentWeekNum < weekNum)
        {
            if (currentDate.DayOfWeek == dayOfWeek)
                currentWeekNum++;
            if (currentWeekNum == weekNum)
                break;
            else
                currentDate = currentDate.AddDays(1);
        }
        return currentDate;
    }
