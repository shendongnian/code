    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime date, 
            DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            DateTime result = date;
            while (result.DayOfWeek != startOfWeek)
                result = date.AddDays(-1);
            return result.Date;
        }
    }
