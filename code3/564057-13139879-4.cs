    // Construct in-memory objects, so it is easier to work with
    var data = table.AsEnumerable().Select(p => 
        new { Key = (int)p["ChNo"], Data = (double)p["ChData"] }).ToArray();
    
    var minValues = data.GroupBy(p => p.Key)
        .ToDictionary(p => p.Key, p => p.Min(i => i.Data));
    
    var res = data.Where(p => minValues[p.Key] == p.Data)
        .OrderBy(p => p.Key)
        .ToArray();
