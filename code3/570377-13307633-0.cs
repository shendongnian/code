    flatList
    .GroupBy(l => new { l.TownId, l.CompanyId })
    .Select(new {
        g => g.Key.TownId
    ,   g => g.Key.CompanyId
    ,   g => g.Select(o => o.ProductId).ToArray()
    ,   g => g.SelectMany(o => o.Prices).ToArray()
    });
