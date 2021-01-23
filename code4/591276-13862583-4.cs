    public static DataTable ToDataTable(this IEnumerable<IDictionary<string, object>> source)
    {
        var result = new DataTable();
        
        foreach(var rowData in source)
        {
            var row = result.NewRow();
            
            if(result.Columns.Count == 0)
            {
                foreach(var columnData in rowData)
                {
                    var column = new DataColumn(columnData.Key,
                                                columnData.Value.GetType())
                    result.Columns.Add(column);
                }
            }
            
            foreach(var columnData in rowData)
                row[columnData.Key] = columnData.Value;
            result.Rows.Add(row);
        }
        
        return result;
    }
