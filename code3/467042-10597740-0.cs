    public class UniqueVisitor_ByDate : AbstractIndexCreationTask<VisitSession, UniqueVisitorByDate>
    {
        public UniqueVisitor_ByDate()
        {
            Map = sessions => from s in sessions
                              select new 
                                         {
                                             s.StartTime.Date,
                                             s.UniqueVisitorId,
                                             Count = 1,
                                         };
            Reduce = results => from result in results
                                group result by result.Date
                                into g
                                select new UniqueVisitorByDate
                                           {
                                               Date = g.Key,
                                               Count = g.Select(x => x.UniqueVisitorId).Distinct().Count(),
                                               UniqueVisitorId = g.FirstOrDefault().UniqueVisitorId,
                                           };
        }
    }
