        private static List<Tuple<DateTime, DateTime>> GetQuarterDates(DateTime startDate, DateTime endDate)
        {
            List<Tuple<DateTime, DateTime>> quarterDates = new List<Tuple<DateTime, DateTime>>();
            
            quarterDates = Enumerable.Range(0, (endDate - startDate).Days)
                .Where(x => startDate.AddMonths(x).Date == new DateTime(startDate.AddMonths(x).Year, (((startDate.AddMonths(x).Month - 1) / 3 + 1) - 1) * 3 + 1, 1))
                .Select(x => new Tuple<DateTime, DateTime>(startDate.AddMonths(x), startDate.AddMonths(x + 3).AddDays(-1)))
                .Where(x => x.Item2 <= endDate).ToList();
            return quarterDates;
        }
