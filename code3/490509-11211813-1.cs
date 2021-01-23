    class Program
    {
    //Helper method to make the Select cleaner:
    private static string GetProperty(IEnumerable<DataRow> rows, string propertyName)
    {
        return rows
            .Where(row => row.Field<string>("Property") == propertyName)
            .Select(c => c.Field<string>("Value"))
            .FirstOrDefault();
    }
    //helper method for populating the datatable
    private static void addRow(DataTable dt, string objectName, string columnName
        , string property, string value)
    {
        var row = dt.NewRow();
        row["ObjectName"] = objectName;
        row["ColumnName"] = columnName;
        row["Property"] = property;
        row["Value"] = value;
        dt.Rows.Add(row);
    }
    
    public static void Main(string[] args)
    {
    
        DataTable dt = new DataTable();
        dt.Columns.Add("ObjectName");
        dt.Columns.Add("ColumnName");
        dt.Columns.Add("Property");
        dt.Columns.Add("Value");
    
        addRow(dt, "foo", "bar", "a", "w");
        addRow(dt, "foo", "bar", "b", "x");
        addRow(dt, "foo", "bar", "c", "y");
        addRow(dt, "foo", "bar", "d", "z");
        addRow(dt, "foo", "test", "a", "i");
        addRow(dt, "foo", "test", "b", "j");
        addRow(dt, "foo", "test", "c", "k");
        addRow(dt, "foo", "test", "d", "l");
    
        var query = dt.AsEnumerable()
            .GroupBy(row => new
            {
                ObjectName = row.Field<string>("ObjectName"),
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
            })
            .CopyToDataTable();
    
        foreach (DataRow row in query.Rows)
        {
            foreach (DataColumn column in query.Columns)
            {
                System.Console.Write(row[column] + "\t");
            }
            System.Console.WriteLine();
        }
    
    
        Console.WriteLine("Press any key to exit. . .");
        Console.ReadKey(true);
    }
    }
