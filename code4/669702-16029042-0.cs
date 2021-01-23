    public void ExportDataTabletoFile(DataTable datatable, string delimited, bool exportcolumnsheader, string file)
    
    {
    
        StreamWriter str = new StreamWriter(file, false, System.Text.Encoding.Default);
    
        if (exportcolumnsheader)
    
        {
    
            string Columns = string.Empty;
    
            foreach (DataColumn column in datatable.Columns)
    
            {
    
                Columns += column.ColumnName + delimited;
    
            }
    
            str.WriteLine(Columns.Remove(Columns.Length - 1, 1));
    
        }
    
        foreach (DataRow datarow in datatable.Rows)
    
        {
    
            string row = string.Empty;
    
     
    
            foreach (object items in datarow.ItemArray)
    
            {
    
     
    
                row += items.ToString() + delimited;
    
            }
    
            str.WriteLine(row.Remove(row.Length - 1, 1));
    
     
    
        }
    
        str.Flush();
    
        str.Close();
    
     
    
    }
