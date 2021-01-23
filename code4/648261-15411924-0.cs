    var yearly = source.Where(p => p.IsYearly)
                       .GroupBy(p => new { Month = p.Date.Month, Day = p.Date.Day })
                       .Select(g => g.First());
    var nonYearly = source.Where(p => !p.IsYearly)
                          .GroupBy(p => p.Date.Date)
                          .Select(g => g.First());
    return yearly.Union(nonYearly).ToList();
