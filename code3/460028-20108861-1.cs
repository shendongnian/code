    // take note of SqlBulkCopyOptions.KeepIdentity , you may or may not want to use this for your situation.  
    using (var bulkCopy = new SqlBulkCopy(_connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
    {
          // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
          foreach (DataColumn col in table.Columns)
          {
              bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
          }
          bulkCopy.BulkCopyTimeout = 600;
          bulkCopy.DestinationTableName = destinationTableName;
          bulkCopy.WriteToServer(table);
    }
