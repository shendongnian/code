     using (SqlConnection connection =new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                            {
                                foreach (var kv in DataTables)
                                {
                                    var table = kv.Value;
                                    if (table.Rows == null || table.Rows.Count == 0)
                                        continue;
    
                                    bulkCopy.DestinationTableName = table.TableName;
                                    bulkCopy.WriteToServer(table);
    
                                }
                            }
                        }
