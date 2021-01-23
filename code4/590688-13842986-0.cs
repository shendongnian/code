    string connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (connection)
                {
                    connection.Open();
                    // Create a table with some rows. 
                    using (var newSessionResults = MakeTable(results))
                    {
                        using (var bulkCopy = new SqlBulkCopy(connection))
                        {
                            bulkCopy.DestinationTableName = "tablename";
    
                            try
                            {
                                // Write from the source to the destination.
                                bulkCopy.WriteToServer(newSessionResults);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                                throw;
                            }
                        }
                    }
                }
            }
