    foreach (var s in series)
    {
        string code = s.SeriesCode;
        if (!dictSeries.ContainsKey(code))
        {
            dictSeries.Add(code, new List<string>());
        }
    
        foreach (var l in s.ProductCodes)
        {
            dictSeries[code].Add(l);
        }
    }
