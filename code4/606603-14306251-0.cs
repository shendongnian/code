    from i in items
    group i by i.Category into categoryGroup
    select new
    {
        Category = categoryGroup.Key,
        Items = categoryGroup.GroupBy(g => g.ItemName)
                             .Select(g => new
                             {
                                 ItemName = g.Key,
                                 QtyNeeded = g.Sum(x => x.QtyNeeded),
                                 QtyFulfilled = g.Sum(x => x.QtyFulfilled)
                             }).ToList()
    };
