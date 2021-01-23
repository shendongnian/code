    var table = new DataTable();
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
    
    
    var data = table.AsEnumerable().Select(p => 
        new { Key = (int)p["ChNo"], Data = (double)p["ChData"] }).ToArray();
    
    var minValues = data.GroupBy(p => p.Key)
        .ToDictionary(p => p.Key, p => p.Min(i => i.Data));
    
    var res = data.Where(p => minValues[p.Key] == p.Data)
        .OrderBy(p => p.Key)
        .ToArray();
