    using (IDataReader reader = new BulkDataReader(new StreamReader("C:\\test.csv"), false))
            {
                String connectionStr = GetConnString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlBulkCopy copy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction);
                    copy.DestinationTableName = "TestTable6";
                    copy.WriteToServer(reader); //ERROR OCCURS HERE: The given value of type String from the data source cannot be converted to type uniqueidentifier of the specified target column
                    transaction.Commit();
                }
                catch (Exception exe)
                {
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
