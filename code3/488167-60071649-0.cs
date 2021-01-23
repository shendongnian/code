        /// <summary>
        /// This presumes that weeks start with Monday.
        /// Week 1 is the 1st week of the year with a Thursday in it.
        /// </summary>
        /// <param name="time">The date to calculate the weeknumber for.</param>
        /// <returns>The year and weeknumber</returns>
        /// <remarks>
        /// Based on Stack Overflow Answer: https://stackoverflow.com/a/11155102
        /// </remarks>
        public static (short year, byte week) GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            // Return the week of our adjusted day
            var week = (byte)CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return ((short)(week >= 52 & time.Month == 1 ? time.Year - 1 : time.Year), week);
        }
