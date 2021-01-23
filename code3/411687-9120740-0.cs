    private const int MaxRetryCount = 3;
    
            public static SqlDataReader RestoreConnectionAndExecuteReader(SqlCommand command)
            {
                return RestoreConnectionAndExecuteQueryHelper(command, true);
            }
    
            public static void RestoreConnectionAndExecuteNonQuery(SqlCommand command)
            {
                RestoreConnectionAndExecuteQueryHelper(command, false);
            }
    
            private static SqlDataReader RestoreConnectionAndExecuteQueryHelper(SqlCommand command, bool returnReader)
            {
                var retryCount = 0;
                while (retryCount++ < MaxRetryCount)
                {
                    try
                    {
                        if (command.Connection.State == ConnectionState.Closed)
                            command.Connection.Open();
                        if (returnReader)
                        {
                            return command.ExecuteReader();
                        }
                        else
                        {
                            command.ExecuteNonQuery();
                            return null;
                        }
                    }
                    catch (Exception e)
                    {
                        if (!e.Message.ToLower().Contains("transport-level error has occurred"))
                        {
                            throw;
                        }
                    }
                }
                throw new Exception("Failed to restore connection for command:" + command.CommandText);
            }
