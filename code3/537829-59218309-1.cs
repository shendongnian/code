    using(SqlConnection sqlConn = new SqlConnection(connectionStringFromDatabase))
        {
          sqlConn.Open();
          using(var adapter = new SqlDataAdapter(String.Format("SELECT * FROM [{0}].[{1}]", schemaName, tableName), sqlConn))
          {
            adapter.Fill(table);
          };
        }
        using(SqlConnection sqlConn = new SqlConnection(connectionStringDestination))
        {
          sqlConn.Open();
          // perform bulk insert
          using(var bulk = new SqlBulkCopy(sqlConn, SqlBulkCopyOptions.KeepIdentity|SqlBulkCopyOptions.KeepNulls, null))
          {
            foreach(DataColumn column in table.Columns)
            {
              bulk.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
            bulk.DestinationTableName = String.Format("[{0}].[{1}]", schemaName, tableName);
            bulk.WriteToServer(table);
          }
        }
