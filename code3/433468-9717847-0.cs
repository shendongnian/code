    foreach (var o in rowEntity.GetType().GetProperties().Where(o => dt.Columns.OfType<DataColumn>()
            .Select(p => p.ColumnName).Contains(o.Name)))
    {
        if (o.Name == "ID")
        {
            // Put a breakpoint here
        }
        o.SetValue(rowEntity, row[o.Name], null));
    }
