    static public List<Tuple<DateTime, DateTime>> GroupByYear(DateTime start, DateTime end)
    {
        List<Tuple<DateTime, DateTime>> datetimes = Enumerable.Range(start.Year + 1, end.Year - 1 - start.Year)
                                                              .Select(x => new Tuple<DateTime, DateTime>(new DateTime(x, 1, 1), new DateTime(x, 12, 31)))
                                                              .ToList();
        datetimes.Add(new Tuple<DateTime, DateTime>(new DateTime(start.Year, 1,1), start));
        datetimes.Add(new Tuple<DateTime, DateTime>(end, new DateTime(end.Year, 12, 31)));
        return datetimes.OrderBy(x => x.Item1.Year).ToList();
    }
