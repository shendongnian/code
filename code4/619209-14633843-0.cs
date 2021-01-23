    public class GroupKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    private IQueryable<ReportSummary> GetReport(Expression<Func<stdReports, GroupKey>> groupKeySelector)
    {
        return Context.stdReports
            .GroupBy(groupKeySelector)
            .Select(g => new ReportSummary
            {
                PKi = g.Key.Id,
                Name = g.Key.Name,
                Sum = g.Sum(report => report.lng_premium),
                Count = g.Count(),
            })
            .OrderBy(summary => summary.Name);
    }
    public List<ReportSummary> ListProducer()
    {
        return GetReport(r =>
            new GroupKey
            {
                Id = r.int_agencyId,
                Name = r.txt_company,
            })
            .ToList();
    }
    
    public List<ReportSummary> ListCarrier()
    {
        return GetReport(r =>
            new GroupKey
            {
                Id = r.int_carrierId,
                Name = r.txt_carrier,
            })
            .ToList();
    }
    
