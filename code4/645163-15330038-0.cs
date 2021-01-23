    public bool AreSameWeekdayEveryMonth(IEnumerable<DateTime> dates)
    {
        var en = dates.GetEnumerator();
        if (en.MoveNext())
        {
            DayOfWeek weekday = en.Current.DayOfWeek;
            DateTime previous = en.Current;
            while (en.MoveNext())
            {
                DateTime d = en.Current;
                if (d.DayOfWeek != weekday || d.Day > 7)
                    return false;
                if (d.Month != previous.Month && ((d - previous).Days == 28 || (d - previous).Days == 35))
                    return false;
                previous = d;
            }
        }
        return true;
    }
