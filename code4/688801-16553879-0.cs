        public static void GetWeek(DateTime dt, CultureInfo ci, out int week, out int year)
        {
            year = dt.Year;
            week = ci.Calendar.GetWeekOfYear(dt, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            int prevweek = ci.Calendar.GetWeekOfYear(dt.AddDays(-7.0), ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if (prevweek + 1 == week) {
                // year of prevweek should be correct
                year = dt.AddDays(-7.0).Year;
            } else {
                // stay here
                year = dt.Year;
            }
        }
