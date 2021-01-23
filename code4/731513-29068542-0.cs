	SqlBulkCopy sbc = new SqlBulkCopy(ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
	sbc.DestinationTableName = "agSoilShapes";
	sbc.ColumnMappings.Add("Mukey", "Mukey");
	sbc.ColumnMappings.Add("Musym", "Musym");
	sbc.ColumnMappings.Add("Shapes", "Shapes");
	DataTable dt = new DataTable();
	dt.Columns.Add("Mukey", typeof(SqlInt32));
	dt.Columns.Add("Musym", typeof(SqlString));
	dt.Columns.Add("Shapes", typeof(SqlGeometry));
