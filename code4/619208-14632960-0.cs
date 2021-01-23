    public List<ReportSummary> GetList(Func<Record, Tuple<string, int>> fieldSelector)
    {
        return (from p in Context.stdReports                    
            group p by fieldSelector(p)
                into g
                select new ReportSummary
                {
                    PKi = g.Key.Item2
                    Name = g.Key.Item1,
                    Sum = g.Sum(foo => foo.lng_premium),
                    Count = g.Count()
                }).OrderBy(q => q.Name).ToList();
    }
