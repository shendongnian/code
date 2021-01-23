    var today = DateTime.Today;
    var beforeMonths = Enumerable.Range(1, 12)
                .Where(i => i < today.Month)
                .Select(i => new DateTime(today.Year, i, 1))
                .ToList();
