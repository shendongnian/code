    private List<DateTime> getWeekDayDates(int month, int year)
    {
        List<DateTime> weekdays = new List<DateTime>();
        DateTime basedt = new DateTime(year, month, 1);
        while ((basedt.Month == month) && (basedt.Year == year))
        {
            if (basedt.DayOfWeek == (DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday))
            {
                weekdays.Add(new DateTime(basedt.Year, basedt.Month, basedt.Day));
            }
            basedt = basedt.AddDays(1);
        }
        return weekdays;
    }
