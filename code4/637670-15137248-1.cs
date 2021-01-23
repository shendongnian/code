    private static DateTime AddDays(DateTime dateTime, int days)
    {
        var daysTimeSpanTicks = (new TimeSpan(days, 0, 0, 0)).Ticks;
        return (days >= 0) ?
            (DateTime.MaxValue.Ticks < dateTime.Ticks + daysTimeSpanTicks) ? dateTime : dateTime.AddDays(days) :
            (dateTime.Ticks + daysTimeSpanTicks < 0) ? dateTime : dateTime.AddDays(days);
    }
