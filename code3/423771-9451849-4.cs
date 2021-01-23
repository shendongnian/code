    public Dictionary<DateTime, DateTime> GetWeeklyDateTimes(DateTime from, DateTime to, DayOfWeek startDay, DayOfWeek endDay)
        {
            int startEndSpan = 7 - endDay - startDay;
            // Subtract days until it falls on our desired start day
            from = from.AddDays(startDay - from.DayOfWeek);
            // Add days until it falls on our desired end day
            to = to.AddDays(to.DayOfWeek - endDay + 2);
            Dictionary<DateTime, DateTime> dateTimes = new Dictionary<DateTime, DateTime>();
            while (to.Subtract(from).Days > startEndSpan)
            {
                dateTimes.Add(from, from.AddDays(startEndSpan));
                from = from.AddDays(startEndSpan + 1);
            }
            return dateTimes;
        }
