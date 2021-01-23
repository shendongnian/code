         static object _lock = new object();
        public static void _main()
        {
                lock (_lock)
                {
                    _bulkcopy(myData);
                }
        }
        public static void _bulkcopy(DataTable dt)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationSettings.AppSettings.Get("DBConnection")))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.BatchSize = 100;
                        bulkCopy.DestinationTableName = "dbo.MyTable";
                        try
                        {
                            bulkCopy.WriteToServer(dt);
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                        }
                    }
                    transaction.Commit();
                }
               
            }
            catch { }
        }
