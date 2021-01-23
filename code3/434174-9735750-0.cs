    public static DataTable BuildDataSetFromDgv(DataGridView _dataGridView, 
        string strTabName, IEnumerable columns)
    {
        DataTable dt = new DataTable();
        dt.TableName = strTabName;
    
        var dvgColumns = columns.Cast<DataGridViewColumn>();
        foreach (var col in dvgColumns)
            dt.Columns.Add(col.DataPropertyName, col.ValueType);
