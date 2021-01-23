    from x in Model
    group by new { x.Date.Year, x.Date.Month } into g
    order by g.Key.Year, g.Key.Month
    select new
    {
        g.Key.Year,
        g.Key.Month,
        Count = g.Select(s => s.ObjectGUID).Distinct().Count()
    }
