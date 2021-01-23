    DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
    foreach (DataRow dr in dt.Rows)
    {
    	foreach (DataColumn col in dt.Columns)
    	{
    		Console.WriteLine("{0,-15}: {1}", col.ColumnName, dr[col]);
    	}
    	Console.WriteLine();
    }
