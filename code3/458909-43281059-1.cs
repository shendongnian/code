        // returns only week number
        // from [Get the correct week number of a given date] thread
        public static int GetIso8601WeekOfYear(DateTime time)
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
            var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return week;
        }
        // returns int YearWeek in format "YYYYWW"
        public static int GetIso8601YearWeekOfYear(DateTime time)
        {
            var firstDayofWeek = time.AddDays((-(int)time.DayOfWeek + (int)DayOfWeek.Monday)); // takeMonday
            var week = GetIso8601WeekOfYear(time);
            var yearWeek = (firstDayofWeek.Year * 100) + week;
            return yearWeek;
        }
        
