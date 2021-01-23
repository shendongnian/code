    static DateTime? GetLastMonthSameNthDayOfWeek(DateTime date)
    {
        int nth = date.Day / 7;
        var prevMonthDay = date.AddMonths(-1);
    
        // find the first date of month having the same day of week
        var d = new DateTime(prevMonthDay.Year, prevMonthDay.Month, 1);
        while(d.Day <= 7)
        {
            if (d.DayOfWeek == date.DayOfWeek)
                break;
            d = d.AddDays(1);
        }
        d = d.AddDays(7 * nth);
        if (d.Month != prevMonthDay.Month)
            return null;
        return d;
    }
