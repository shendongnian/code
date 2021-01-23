    public static DataTable DataTableJoiner(DataTable dt1, DataTable dt2)
	{
		DataTable targetTable = dt1.Clone();
		
		var dt2Query = dt2.Columns.OfType<DataColumn>().Select(dc =>
			new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, 
				dc.ColumnMapping));
			
        var dt2FilterQuery = from dc in dt2Query.AsEnumerable()
                             where !targetTable.Columns.Contains(dc.ColumnName)
                             select dc;
            
        var columnsToAdd = dt2FilterQuery.ToArray();
        var columnsIndices = columnsToAdd.Select(dc => dt2.Columns.IndexOf(dc.ColumnName));
            
        targetTable.Columns.AddRange(columnsToAdd);
			
        var rowData = from row1 in dt1.AsEnumerable()
						  join row2 in dt2.AsEnumerable()
						  on row1.Field<int>("Code") equals 
							 row2.Field<int>("Code")
						  select row1.ItemArray
							  .Concat(row2.ItemArray
							  .Where((r2,idx) => 
								  columnsIndices.Contains(idx))).ToArray();
                                  
		foreach (object[] values in rowData) targetTable.Rows.Add(values);
		return targetTable;
	}
