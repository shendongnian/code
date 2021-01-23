         public static int WeekNumber(this DateTime date)
        {
            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            DayOfWeek day = cal.GetDayOfWeek(date);
            date = date.AddDays(4 - ((int)day == 0 ? 7 : (int)day));
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
