    var toRemove = sourceProductList
        .GroupBy(p => p.Name)
        .Where(g => g.Count() > 1)
        .SelectMany(g => g)
        .GroupBy(p => p.Price)
        .Where(g => g.Count() > 1)
        .SelectMany(g => g.Select(p => p.ID))
        .Distinct()
        .ToList();
    toRemove.ForEach(id => sourceProductList.RemoveAll(p => p.ID == id));
