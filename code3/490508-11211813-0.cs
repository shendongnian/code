    //Helper method to make the Select cleaner:
    private static string GetProperty(IEnumerable<DataRow> rows, string propertyName)
    {
        return rows
            .Where(row => row.Field<string>("Property") == propertyName)
            .Select(c => c.Field<string>("Value"))
            .FirstOrDefault();
    }
    
    //actual query:
    var query = dt.AsEnumerable()
        .GroupBy(row => new
        {
            ObjectName = row.Field<string>("ObjectName "),
            ColumnName = row.Field<string>("ColumnName")
        })
        .Select(g => new
        {
            ObjectName = g.Key.ObjectName,
            ColumnName = g.Key.ColumnName,
            a = GetProperty(g, "a"),
            b = GetProperty(g, "b"),
            c = GetProperty(g, "c"),
            d = GetProperty(g, "d"),
        });
