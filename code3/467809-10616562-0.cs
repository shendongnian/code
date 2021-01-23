	using (OleDbDataAdapter adapter = new OleDbDataAdapter(tableRows, connStr))
	{
		DataTable table = new DataTable();
		adapter.Fill(table);
		table.Columns.Add(new DataColumn("@ColumnName", typeof(string), string.Format("'{0}'", textboxvalue)));
		// SQL Server Connection String
		string sqlConnectionString = "SERVER=<server>;UID=schafc;Trusted_Connection=Yes;DATABASE=<database>;";
		// Bulk Copy to SQL Server
		using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
		{
			bulkCopy.DestinationTableName = tableName;
			bulkCopy.WriteToServer(table);
		}
	}
