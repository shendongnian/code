	DataRow row = table.NewRow();
	// Set know columns...
	row["ColumnName"] = new object();
	// or check column exists, is expected type etc first
	if (table.Columns.Contains("ColumnName") 
        && table.Columns["ColumnName"].DataType == typeof(string)) {
		row["ColumnName"] = "String";
	}
	table.Rows.Add(row);
