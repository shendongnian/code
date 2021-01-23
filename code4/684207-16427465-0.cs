    var result = objectTable.AsEnumerable()
        .Select(r => new { Row = r, Title = r.Field<string>("Title"), Month = r.Field<int>("Month") })
        .GroupBy(x => new { x.Title, x.Month })
        .Select( g => new { 
            id = g.First().Row.Field<Guid>("id"), 
            g.Key.Title, 
            g.Key.Month, 
            Year = g.Select(x => x.Row.Field<string>("Year")).ToList()
        });
