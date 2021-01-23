    private const int MaxRetryCount = 3;
    public static T RestoreConnectionAndExecute<T>(SqlCommand command, Func<SqlCommand, T> func)
    {
        int retryCount = 0;
        while (retryCount++ < MaxRetryCount)
        {
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                return func(command);
            }
            catch(Exception e)
            {
                if(!e.Message.ToLower().Contains("transport-level error has occurred"))
                {
                    throw;
                }
            }
        }
        throw new Exception("Failed to restore connection for command:"+command.CommandText);
    
    } 
    public static SqlDataReader RestoreConnectionAndExecuteReader(SqlCommand command)
    {
        return RestoreConnectionAndExecute(command, c => c.ExecuteReader());
    }
    public static int RestoreConnectionAndExecuteNonQuery(SqlCommand command)
    {
        return RestoreConnectionAndExecute(command, c => c.ExecuteNonQuery());
    }
