    public static class DateTimeExtensions {
        public static DateTime NearestQuarterEnd(
            this DateTime date,
            int firstMonthOfFiscalYear
        ) {
            IEnumerable<DateTime> candidates =
                QuartersInYear(date.Year, firstMonthOfFiscalYear)
                    .Union(QuartersInYear(date.Year - 1, firstMonthOfFiscalYear));
            return candidates.Where(d => d <= date).OrderBy(d => d).Last();
        }
        static IEnumerable<DateTime> QuartersInYear(
            int year,
            int firstMonthOfFiscalYear
        ) {
            Contract.Requires(firstMonthOfFiscalYear >= 1 
                && firstMonthOfFiscalYear <= 12);
            return Enumerable
                      .Range(0, 4)
                      .Select(k => firstMonthOfFiscalYear + 3 * k)
                      .Select(m => m <= 12 ? m : m % 12)
                      .Select(m => new DateTime(year, m, 1))
                      .ToList();
   
        }
    }
