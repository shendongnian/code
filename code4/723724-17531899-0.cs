        public IEnumerable<DateTime> SundaysBetween(DateTime start, DateTime end)
        {
            while (start.DayOfWeek != DayOfWeek.Sunday)
                start = start.AddDays(1);
            while (start <= end)
            {
                yield return start;
                start = start.AddDays(7);
            }
        }
