        public static DateTime FirstDateOfWeek(int year, int weekOfYear, CultureInfo ci)
        {
            DateTime jul1 = new DateTime(year, 7, 1);
            while (jul1.DayOfWeek != ci.DateTimeFormat.FirstDayOfWeek)
            {
                jul1 = jul1.AddDays(1.0);
            }
            int refWeek = ci.Calendar.GetWeekOfYear(jul1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            int weekOffset = weekOfYear - refWeek;
            return jul1.AddDays(7 * weekOffset );
        }
