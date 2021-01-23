     using (SqlConnection connection =new SqlConnection(connectionString))
     {
            connection.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
             {                               
                      bulkCopy.DestinationTableName = table.TableName;
                      bulkCopy.WriteToServer(table);
             }
      }
