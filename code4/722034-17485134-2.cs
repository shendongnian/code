    public static DateTime GetFirstDay(int year, int month, DayOfWeek dayOfWeek)
    {
        return Enumerable.Range(1, 7).
                          Select(day => new DateTime(year, month, day)).
                          First(dateTime => (dateTime.DayOfWeek == dayOfWeek));
    }
