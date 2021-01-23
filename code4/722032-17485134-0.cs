    public static DateTime GetFirstDay(int year, int month, DayOfWeek day)
    {
        DateTime result = new DateTime(year, month, 1);
        while (result.DayOfWeek != day)
        {
            result = result.AddDays(1);
        }
        return result;
    }
