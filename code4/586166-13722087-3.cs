        // connect to SQL
        using (SqlConnection connection = new SqlConnection(connString))
        {
            // make sure to enable triggers
            // more on triggers in next post
            SqlBulkCopy bulkCopy = new SqlBulkCopy(
                connection, 
                SqlBulkCopyOptions.TableLock | 
                SqlBulkCopyOptions.FireTriggers | 
                SqlBulkCopyOptions.UseInternalTransaction,
                null
                );
    
            // set the destination table name
            bulkCopy.DestinationTableName = this.tableName;
            connection.Open();
    
            // write the data in the "dataTable"
            bulkCopy.WriteToServer(dataTable);
            connection.Close();
        }
        // reset
        this.dataTable.Clear();
