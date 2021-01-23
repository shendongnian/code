    var attributes = this.GetType().GetCustomAttributes(typeof(ColumnNames), false);
    foreach (var attr in attributes)
    {
        var a = attr as ColumnNames;
        foreach (var column in a.Values)
        {
            this.Columns.Add(column);
        }
    }
