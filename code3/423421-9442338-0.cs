    private bool IsLastOfMonth(DateTime date)
    {
        var oneWeekAfter = date.AddDays(7);
        return oneWeekAfter.Month != date.Month;
    }
