    private static void updateDatabase(DataTable targetTable)
        {
            try
            {
                DataSet ds = new DataSet("FileFolderAttribute");
                ds.Tables.Add(targetTable);
                writeToLog(targetTable.TableName + " - Rows: " + targetTable.Rows.Count, logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                writeToLog(@"Opening SQL connection", logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                Console.WriteLine(@"Opening SQL connection");
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
                sqlConnection.Open();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                bulkCopy.DestinationTableName = "FileFolderAttribute";
                writeToLog(@"Copying data to SQL Server table", logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                Console.WriteLine(@"Copying data to SQL Server table");
                foreach (var table in ds.Tables)
                {
                    writeToLog(table.ToString(), logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                    Console.WriteLine(table.ToString());
                }
                bulkCopy.WriteToServer(ds.Tables[0]);
                sqlConnection.Close();
                sqlConnection.Dispose();
                writeToLog(@"Closing SQL connection", logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                writeToLog(@"Clearing local DataTable...", logDatabaseFile, getLineNumber(), getCurrentMethod(), true);
                Console.WriteLine(@"Closing SQL connection");
                Console.WriteLine(@"Clearing local DataTable...");
                targetTable.Clear();
                ds.Tables.Remove(targetTable);
                ds.Clear();
                ds.Dispose();
            }
            catch (Exception error)
            {
                errorLogging(error, getCurrentMethod(), logDatabaseFile);
            }
        }
