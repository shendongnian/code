    static DateTime? GetLastMonthSameNthDayOfWeek(DateTime date)
    {
        int nth = date.Day / 7; // returns 0 if 1st, 1 if 2nd...
        var prevMonthDay = date.AddMonths(-1);
    
        // find the first date of month having the same day of week
        var d = new DateTime(prevMonthDay.Year, prevMonthDay.Month, 1);
        while(d.Day <= 7)
        {
            if (d.DayOfWeek == date.DayOfWeek)
                break;
            d = d.AddDays(1);
        }
        // got to nth day of week
        d = d.AddDays(7 * nth);
        // if we have passed the current month, there's no nth day of week
        if (d.Month != prevMonthDay.Month)
            return null;
        return d;
    }
