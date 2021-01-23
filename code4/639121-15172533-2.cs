        public static List<DateTime> GetDayOccurrences(DayOfWeek day, DateTime from, DateTime to)
        {
            var results = new List<DateTime>();
            while (from <= to)
            {
                if (from.DayOfWeek == day)
                {
                    results.Add(from);
                    from = from.AddDays(7);
                }
                else
                {
                    from = from.AddDays(1);
                }
            }
            return results;
        }
