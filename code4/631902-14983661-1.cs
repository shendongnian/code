    public static DateTime AddWorkingDays(DateTime start, int workingDays, Predicate<DateTime> isHoliday)
    {
        DateTime date;
        for (date = start; workingDays > 0; date = date.AddDays(1))
        {
            if (!isHoliday(date))
            {
                --workingDays;
            }
        }
        return date;
    }
