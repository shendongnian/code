    public static class DateExtensions
    {
        public static DateTime BeginningOfWeek(this DateTime date, 
                               DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            if (date.DayOfWeek == firstDayOfWeek)
                return date.Date;
    
            DateTime result = date.AddDays(-1);
    
            while (result.DayOfWeek != firstDayOfWeek)
                result = result.AddDays(-1);
    
            return result.Date;
        }
    }
