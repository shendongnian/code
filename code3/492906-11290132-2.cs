    var result = <query>;
    int lastMonth = 1;
    var unionresults = result.SelectMany(r =>
    {
        var results = new[] { r }.AsEnumerable();
        if (lastMonth > r.Month)
        {
            results = Enumerable.Range(lastMonth, 12 - lastMonth).Select(month => new { Year = r.Year, Month = month, Count = 0 })
                .Concat(Enumerable.Range(1, r.Month).Select(month => new { Year = r.Year, Month = month, Count = 0 }))
                .Concat(results);
        }
        else if (lastMonth < r.Month)
        {
            results = Enumerable.Range(lastMonth, r.Month - lastMonth)
                .Select(month => new { Year = r.Year, Month = month, Count = 0 })
                .Concat(results);
        }
        lastMonth = r.Month + 1;
        if (lastMonth > 12)
        {
            lastMonth = 1;
        }
        return results;
    });
