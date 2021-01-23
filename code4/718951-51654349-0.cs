            //you can try like that 
            int weeks = DateHelper.GetWeeksInGivenYear(2018);
            int weeks = DateHelper.GetWeeksInGivenYear(2020);
            // This presumes that weeks start with Monday.
            // Week 1 is the 1st week of the year with a Thursday in it.
            public static int GetIso8601WeekOfYear(this DateTime time)
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
                return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }
        
            //gets given year last week no
            public static int GetWeeksInGivenYear(int year)
            {
                DateTime lastDate = new DateTime(year, 12, 31);
                int lastWeek = GetIso8601WeekOfYear(lastDate);
    
                while (lastWeek == 1)
                {
                    lastDate = lastDate.AddDays(-1);
                    lastWeek = GetIso8601WeekOfYear(lastDate);
    
                }
                return lastWeek;
            }
