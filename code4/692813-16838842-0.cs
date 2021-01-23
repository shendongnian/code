    void MergeColumns_SO16666297(DataTable destination, DataTable source, IEnumerable<string> columnsToSkip)
    {
    if(columnsToSkip==null) columnsToSkip= new List<string>();
    foreach(var col in source.Columns.OfType<DataColumn>().Where(col=>!columnsToSkip.Contains(col.ColumnName)))
    	{
    		var newCol = destination.Columns.Add(col.ColumnName, col.DataType);
    		newCol.AllowDBNull = true ;
    		destination.Rows[0][newCol] = source.Rows[0][col];
    	}
    }
