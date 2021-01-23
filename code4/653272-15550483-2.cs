    private static DateTime GetNextOccurrence(DateTime initialDate, 
                                              DateTime lastOccurrence, 
                                              Periods p)
    {
        switch (p)
        {
            case Periods.Day: return lastOccurrence.AddDays(1);
            case Periods.Week: return lastOccurrence.AddDays(7);
            case Periods.BiWeek: return lastOccurrence.AddDays(14);
            case Periods.Month:
            case Periods.BiMonth:
              {
                  DateTime dt = lastOccurrence.AddMonths(p == Periods.Month ? 1 : 2);
                  int maxDays = DateTime.DaysInMonth(dt.Year, dt.Month);
                  int days = Math.Min(initialDate.Day, maxDays);
                  return new DateTime(dt.Year, dt.Month, days);
              }
            case Periods.Year: return lastOccurrence.AddYears(1);
            default: return lastOccurrence;
        }
    }
