    public class DateTimeRange
    {
        Date StartDate { get; set; }
        Date EndDate { get; set; }
        float NumberOfMonths { get; set; }
    }
    public static IEnumerable<DateTimeRange> SplitByMonths(DateTime start, 
                                                           DateTime end, 
                                                           Calendar cal)
    {
        return (
            from y in Enumerable.Range(start.Year, end.Year - start.Year + 1)
            let maxMonth = y < end.Year ? cal.GetMonthsInYear(y) : end.Month
            let minMonth = y > start.Year ? 1 : start.Month
            from m in Enumerable.Range(minMonth, maxMonth - minMonth + 1)
            let isStart = (y == start.Year && m == start.Month) 
            let isEnd = (y == end.Year && m == end.Month) 
            select new DateTimeRange
            {
                StartDate = isStart ? start : new DateTime(y, m, 1),
                EndDate = isEnd ? end : new DateTime(y, m, cal.GetDaysInMonth(y, m)),
                NumberOfMonths = isStart || isEnd ? .5 : 1
            });
    }
