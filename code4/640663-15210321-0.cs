    class Test
        {
            static void Main(string[] args)
            {
                var weekdays = new[] { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
                var result = GetDateRange(DateTime.Today, DateTime.Today.AddDays(14))
                    .Where(d => weekdays.Contains(d.DayOfWeek));
            }
    
            public static IEnumerable<DateTime> GetDateRange(DateTime start, DateTime end)
            {
                DateTime date = start;
    
                do
                {
                    yield return date;
                    date = date.AddDays(1);
                }
                while (date < end);
            }
        }
