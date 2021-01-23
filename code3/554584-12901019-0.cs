    groups
     .Select(g => new {
        g.Key.Width, 
        g.Key.Length, 
        g.Key.Height, 
        columnNames = g.Select(x => x.ColumnName),
        number = g.Count()})
