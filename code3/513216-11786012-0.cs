    XElement root = XElement.Load(file);
    var tables = root.Descendants("Table1")
                     .Select(t => new
                     {
                         Server = t.Element("Server").Value,
                         Database = t.Element("Database").Value
                     });
    
    foreach(var table in tables)
        grid.Rows.Add(new object[] { table.Server, table.Database });
