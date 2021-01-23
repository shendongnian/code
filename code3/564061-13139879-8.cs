    // Prepare the data
    var table = new DataTable();    
    // The type must be specified explicitly,
    // otherwise it will be string
    table.Columns.Add("ChNo", typeof(int));
    table.Columns.Add("ChData", typeof(double));
    
    new[]
    {
        new {Key = 1, Data = 0.0},
        new {Key = 1, Data = 0.1},
        new {Key = 2, Data = 0.0},
        new {Key = 1, Data = 0.0},
        new {Key = 2, Data = 0.1},
        new {Key = 1, Data = 0.0},
        new {Key = 1, Data = 0.0},
        new {Key = 2, Data = 0.0},
    }
    .ToList().ForEach(p => table.Rows.Add(p.Key, p.Data));
    // Make a projection, so it is easier to work with
    var data = table.AsEnumerable().Select(p => 
        new { Key = p["ChNo"], Data = p["ChData"] }).ToArray();
    
    var minValues = data.GroupBy(p => p.Key)
        .ToDictionary(p => p.Key, p => p.Min(i => i.Data));
    
    var res = data.Where(p => minValues[p.Key] == p.Data)
        .OrderBy(p => p.Key)
        .ToArray();
