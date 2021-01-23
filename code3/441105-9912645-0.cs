        static IList<Tuple<DateTime, DateTime>> GetDateRangesByYear(DateTime start, DateTime end)
        {
            List<Tuple<DateTime, DateTime>> ranges = new List<Tuple<DateTime,DateTime>>();
            for (int year = start.Year; year <= end.Year; ++year)
            {
                DateTime yearBegin = year == start.Year ? start : new DateTime(year, 1, 1);
                DateTime yearEnd = year == end.Year ? end : new DateTime(year, 12, 31);
                ranges.Add(Tuple.Create(yearBegin, yearEnd));
            }
            return ranges;
        }
