    public VisitSummaryByDateIndex()
    {
        AddMap<VisitSession>(sessions => from s in sessions
                                            select new VisitSummaryByDate
                                            {
                                                Date = s.StartTime.Date,
                                                TotalVisitSessions = 1,
                                                TotalPageVisits = 0,
                                                TotalNewVisitors = s.IsNewVisit ? 1 : 0,
                                                TotalUniqueVisitors = 1,
                                                UniqueVisitorId = new[]{s.UniqueVisitorId}
                                            });
        AddMap<PageVisit>(visits => from v in visits
                                    select new VisitSummaryByDate
                                    {
                                        Date = v.VisitTime.Date,
                                        TotalVisitSessions = 0,
                                        TotalPageVisits = 1,
                                        TotalNewVisitors = 0,
                                        TotalUniqueVisitors = 0,
                                        UniqueVisitorId = new string[0]
                                    });
        Reduce = results => from result in results
                            group result by result.Date into g
                            select new VisitSummaryByDate
                            {
                                Date = g.Key,
                                TotalVisitSessions = g.Sum(it => it.TotalVisitSessions),
                                TotalPageVisits = g.Sum(it => it.TotalPageVisits),
                                TotalNewVisitors = g.Sum(it => it.TotalNewVisitors),
                                TotalUniqueVisitors = g.Sum(it => it.TotalUniqueVisitors),,
                                UniqueVisitorId =  g.Select(x=>x.UniqueVisitorId).Distinct()
                            };
    }
}
