    private TReturn RestoreConnectionAndExecute<T>(SqlCommand command, Func<SqlCommand, TReturn> execute) 
    {
       int retryCount = 0;
       while (retryCount++ < MaxRetryCount)
       {
           try
           {
              if (command.Connection.State == ConnectionState.Close) 
                  command.Connection.Open();
              return execute(command);
           } 
           catch(Exception e)
           {
              ...
       }
    }
    public SqlDataReader RestoreConnectionAndExecuteReader(SqlCommand command) 
    {
       return this.RestoreConnectionAndExecute(command, c => c.ExecuteReader());
    }
    public void RestoreConnectionAndExecuteNonQuery(SqlCommand command)
    {
       // Ignore return
       this.RestoreConnectionAndExecute(command, c => c.ExecuteNonQuery());
    }
