    var dates = dataContext.Activities
        .Where(a => a.IsResolved && a.ResolvedBy == userId)
        .Select(a => a.ResolvedDate)
        .ToList();
    var count = dates.Count;
