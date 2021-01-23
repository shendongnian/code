    public static IEnumerable<DateTime> GetAllWeekStartingDays(this DateTime start, DateTime end, DayOfWeek firstDayOfWeek)
            {
                 return Enumerable
                        .Range(0, end.Subtract(start).Days + 1).Select(offset => start.AddDays(offset))
                        .Where(d => d.DayOfWeek == firstDayOfWeek);             
            }
