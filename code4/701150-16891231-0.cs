	using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.KeepIdentity))
	{
		bulkCopy.DestinationTableName = DestTableName;
		string[] DtColumnName = YourDataTable;
		foreach (string dbcol in DbColumnName)//To map Column of Datatable to that of DataBase tabele
		{
			foreach (string dtcol in DtColumnName)
			{
				if (dbcol.ToLower() == dtcol.ToLower())
				{
					SqlBulkCopyColumnMapping mapID = new SqlBulkCopyColumnMapping(dtcol, dbcol);
					bulkCopy.ColumnMappings.Add(mapID);
					break;
				}
			}
		}
		bulkCopy.WriteToServer(DestTableName.CreateDataReader());
		bulkCopy.Close();
	}
