        const string connectionString = "YOUR ACCESS CONNECTION STRING";
        const string connectionStringDest = "YOUR SQL SERVER CONNECTION STRING";
        using (var sourceConnection =
              new OleDbConnection(connectionString))
        {
            sourceConnection.Open();
            var commandSourceData = new OleDbCommand(
                "SELECT COL1, COL2 FROM TABLE_X;", sourceConnection);
            var reader =
                commandSourceData.ExecuteReader();
            using (var destinationConnection =
                       new SqlConnection(connectionStringDest))
            {
                destinationConnection.Open();
                using (var bulkCopy =
                           new SqlBulkCopy(destinationConnection))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.TABLE_DEST";
                    try
                    {
                        bulkCopy.WriteToServer(reader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
        }
