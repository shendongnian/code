    if (table.Rows.Count > 0)
    {
    	foreach (System.Data.DataColumn col in table.Columns)
    	{
    		System.Diagnostics.Debug.WriteLine(col.ColumnName);
    	}
    }
