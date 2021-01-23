    string[] colsToConsider = ...
    
    var allDuplicates = dt.AsEnumerable()
                          .GroupBy(dr => colsToConsider.Select(dr.Field<object>)
                                                       .ToArray(),
                                   new ArrayEqualityComparer<object>())       
                          .Where(g => g.Count() > 1)
                          .SelectMany(g => g)
                          .CopyToDataTable();
