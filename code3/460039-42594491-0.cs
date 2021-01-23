    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = 
                    "dbo.BulkCopyDemoMatchingColumns";
                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(ExitingSqlTableName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
