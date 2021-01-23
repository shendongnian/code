       public class DateTimeSpan
        {
            public DateTime WeekStartDate;
            public DateTime WeekEndDate;
            public DateTime MonthStartDate;
            public DateTime MonthEndDate;
            public DateTime YearStartDate;
            public DateTime YearEndDate;
            public int WeekNum;
            
        }
        public static DateTimeSpan TimeProperties(this DateTime str)
        {
            if (str == null) return null;
            DateTimeSpan dts = new DateTimeSpan();
            dts.WeekNum=     CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(str, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            dts.WeekStartDate = GetFirstDayOfWeek(str);
            dts.WeekEndDate = GetLAstDayOfWeek(str);
            dts.MonthStartDate = new DateTime(str.Year, str.Month, 1);
            int numberOfDays = DateTime.DaysInMonth(str.Year, str.Month);
            DateTime last = new DateTime(str.Year, str.Month, numberOfDays);
            dts.MonthEndDate = last;
            dts.YearStartDate = new DateTime(str.Year, 1, 1);
            numberOfDays = DateTime.DaysInMonth(str.Year, 12);
            last = new DateTime(str.Year, 12, numberOfDays);
            dts.YearEndDate = last;
         
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
