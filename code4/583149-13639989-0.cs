    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = 
                        "dbo.BulkCopyDemoMatchingColumns";
    
                    try
                    {
                        // Write from the source to the destination.
                        // Check if the data set is not null and tables count > 0 etc
                        bulkCopy.WriteToServer(yourDataSet.Tables[0]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
