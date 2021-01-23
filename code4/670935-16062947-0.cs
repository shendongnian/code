    int? col1 = null;
    int? col2 = null;
    int? col3 = null;
    ProductHistorical.GroupBy(p=>p.IdProduct)
    .Select(grp => grp.OrderBy(p=> p.DateChange)
        .Select(p => {
            var changed = col1 != p.Col1 || col2 != p.Col2 || col3 != p.Col3;
            col1 = p.Col1; col2 = p.Col2; col3 = P.Col3;
            return new { p = p, changed = changed };
        }
        .Where(p => p.changed)
        .Select(p => p.p)
    )
    .SelectMany(p => p)
