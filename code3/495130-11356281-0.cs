    public class OminitureStats
    {
        public int PageViews { get; set; }
        public int MonthlyUniqueVisitors { get; set; }
        public int Visits { get; set; }
        public double PagesPerVisit { get; set; }
        public double BounceRate { get; set; }
    }
    private IQueryable<OminitureStats> GetOmnitureDataAsQueryable(int? fnsId, int dateRange)
    {
        var yesterday = DateTime.Today.AddDays(-1);
        var nDays = yesterday.AddDays(-dateRange);
        if (fnsId.HasValue)
        {
            IQueryable<OminitureStats> query = from o in lhDB.omniture_stats
                                               where o.fns_id == fnsId
                                                     && o.date <= yesterday
                                                     && o.date > nDays
                                               select new OminitureStats() { 
                                                   o.page_views.GetValueOrDefault(), 
                                                   o.monthly_unique.GetValueOrDefault(),
                                                   o.visits.GetValueOrDefault(),
                                                   (double)o.bounce_rate.GetValueOrDefault()
                                               };
            return query;
        }
        return null;
    }
