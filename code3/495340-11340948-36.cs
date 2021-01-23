        public static IQueryable<DateTime> CreateDates(this IQueryable<DateRange> rtbl)
        {
            var result = new List<DateTime>();
            foreach (var dr in rtbl)
            {
                var q = from i in Enumerable.Range(0, dr.CalcDays())
                        select (DateTime)dr.fromDate.AddDays(i);
                foreach (var d in q) result.Add(d);
            }
            return result.AsQueryable<DateTime>();
        }
