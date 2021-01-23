    // Prepare the data
    var table = new DataTable();    
    // The type must be specified explicitly,
    // otherwise the casting will give a run-time error
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
