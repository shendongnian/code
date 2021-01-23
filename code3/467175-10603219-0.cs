    public class VisitSummaryByDateIndex : AbstractMultiMapIndexCreationTask<VisitSummaryByDate>
    {
        public VisitSummaryByDateIndex()
        {
            AddMap<VisitSession>(sessions => from s in sessions
                                             select new VisitSummaryByDate
                                             {
                                                 Date = s.StartTime.Date,
                                                 TotalVisitSessions = 1,
                                                 TotalPageVisits = 0,
                                                 TotalNewVisitors = s.IsNewVisit ? 1 : 0,
                                                 TotalUniqueVisitors = 0,
                                                 UniqueVisitorId = s.UniqueVisitorId
                                             });
            AddMap<PageVisit>(visits => from v in visits
                                        select new VisitSummaryByDate
                                        {
                                            Date = v.VisitTime.Date,
                                            TotalVisitSessions = 0,
                                            TotalPageVisits = 1,
                                            TotalNewVisitors = 0,
                                            TotalUniqueVisitors = 0,
                                            UniqueVisitorId = string.Empty,
                                        });
            Reduce = results => from result in results
                                group result by result.Date into g
                                select new VisitSummaryByDate
                                {
                                    Date = g.Key,
                                    TotalVisitSessions = g.Sum(it => it.TotalVisitSessions),
                                    TotalPageVisits = g.Sum(it => it.TotalPageVisits),
                                    TotalNewVisitors = g.Sum(it => it.TotalNewVisitors),
                                    TotalUniqueVisitors = g.Select(it => it.UniqueVisitorId).Where(x => x.Length > 0).Distinct().Count(),
                                    UniqueVisitorId = g.FirstOrDefault().UniqueVisitorId,
                                };
        }
    }
