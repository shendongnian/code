        foreach (var item in ids)
        {
             DataRow row = localTempTable.NewRow();
             row[0] = item;
             localTempTable.Rows.Add(row);
        }
        localTempTable.AcceptChanges();
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
        {
            bulkCopy.DestinationTableName = "##" + tableName;
            bulkCopy.WriteToServer(localTempTable);
        }
