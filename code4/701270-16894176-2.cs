        var importData = new DataSet();
        xmlData.Position = 0;
        importData.ReadXml(xmlData);
        using (var connection = new SqlConnection(myConnectionString))
        {
          connection.Open();
          using (var trans = connection.BeginTransaction())
          {
            using (var sbc = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, trans) { DestinationTableName = myTableName })
            {
              foreach (DataColumn col in importData.Tables[0].Columns)
              {
                sbc.ColumnMappings.Add(col.ColumnName, col.ColumnName);
              }
              sbc.WriteToServer(importData.Tables[0]); //table 0 is the main table in this dataset
              // Now lets call the stored proc.
              var cmd = new SqlCommand("ProcessDataImport", connection)
                  {
                    CommandType = CommandType.StoredProcedure
                  };
              cmd.CommandTimeout = 1200;
              cmd.ExecuteNonQuery();
              trans.Commit();
            }
            connection.Close();
            return null;
          }
        }
