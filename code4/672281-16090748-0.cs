    foreach (var col in table.Columns)
    {
        var propInfo = obj.GetType().GetProperty(col.Name);
        if (propInfo == null) { continue; }
        propInfo.SetValue(obj, row[col.Name], null);
    }
