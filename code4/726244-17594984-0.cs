    public static List<RowData> ToDataTable<T>(IEnumerable<T> source)
    {
        System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
        List<RowData> rows = new List<JQGridRow>();
     
        foreach (var item in source)
        {
            RowData row = new RowData();
            row.cells = new string[properties.Length];
            int i=0;
            foreach (var prop in properties)
            {  
                 row.cells[i] = prop.GetValue(item, null);i++;
            }
           rows.Add(row);
        }
        return rows;
    }
