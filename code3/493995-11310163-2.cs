       public class DateTimeSpan
        {
            public DateTime StartDate;
            public DateTime EndDate;
            public int WeekNum;
            
        }
    
        public static DateTimeSpan WeekProperties(this DateTime str)
        {
            if (str == null) return null;
            DateTimeSpan dts = new DateTimeSpan();
            dts.WeekNum=     CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(str, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            dts.StartDate = GetFirstDayOfWeek(str);
            dts.EndDate = GetLAstDayOfWeek(str);
            return dts;
        }
        
    
        static DateTime GetFirstDayOfWeek(DateTime date)
        {
            var firstDayOfWeek = date.AddDays(-((date.DayOfWeek - DayOfWeek.Sunday + 7) % 7));
            if (firstDayOfWeek.Year != date.Year)
                firstDayOfWeek = new DateTime(date.Year, 1, 1);
            return firstDayOfWeek;
        }
    
        static DateTime GetLAstDayOfWeek(DateTime date)
        {
            var firstDayOfWeek = date.AddDays(((DayOfWeek.Saturday - date.DayOfWeek + 7) % 7));
            if (firstDayOfWeek.Year != date.Year)
                firstDayOfWeek = new DateTime(date.Year, 12, 31);
            return firstDayOfWeek;
        }
