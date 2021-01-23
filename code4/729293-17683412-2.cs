    public static class DateTimeExtensions {
        public static DateTime NearestQuarterEnd(
            this DateTime date,
            int firstMonthOfFiscalYear
        ) {
            IEnumerable<DateTime> candidates =
                QuartersInYear(date.Year, firstMonthOfFiscalYear)
                    .Concat(QuartersInYear(date.Year - 1, firstMonthOfFiscalYear));
            return candidates.SkipWhile(d => d > date).First();
        }
        static Dictionary<Tuple<int, int>, List<DateTime>> dict =
            new Dictionary<Tuple<int, int>, List<DateTime>>();
        static IEnumerable<DateTime> QuartersInYear(
            int year,
            int firstMonthOfFiscalYear
        ) {
            Contract.Requires(firstMonthOfFiscalYear >= 1 
                && firstMonthOfFiscalYear <= 12);
            var key = Tuple.Create(year, firstMonthOfFiscalYear);
            if(dict.ContainsKey(key)) {
                return dict[key];
            }
            else {
                var value =
                    Enumerable
                      .Range(0, 4)
                      .Select(k => firstMonthOfFiscalYear + 3 * k)
                      .Select(m => m <= 12 ? m : m % 12)
                      .Select(m => new DateTime(year, m, 1))
                      .OrderByDescending(d => d)
                      .ToList();
                dict.Add(key, value);
                return value;
            }
        }
    }
