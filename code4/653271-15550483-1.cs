    private static DateTime GetNextOccurrence(DateTime initialDate, DateTime lastOccurrence, Periods p)
    {
        switch (p)
        {
            case Periods.Day: return lastOccurrence.AddDays(1);
            case Periods.Week: return lastOccurrence.AddDays(7);
            case Periods.BiWeek: return lastOccurrence.AddDays(14);
            case Periods.Month:
            case Periods.BiMonth:
                {
                    DateTime date = lastOccurrence.AddMonths(p == Periods.Month ? 1 : 2);
                    int days = Math.Min(initialDate.Day, DateTime.DaysInMonth(date.Year, date.Month));
                    return new DateTime(date.Year, date.Month, days);
                }
            case Periods.Year: return lastOccurrence.AddYears(1);
            default: return lastOccurrence;
        }
    }
