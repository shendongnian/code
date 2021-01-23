    public class GroupKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    private IQueryable<ReportSummary> GetReport(
        Expression<Func<stdReport, GroupKey>> groupKeySelector)
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
