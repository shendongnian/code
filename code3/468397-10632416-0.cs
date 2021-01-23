    public static CommandIntercepter 
    {
      void ExecuteNonQuery(IDbCommand command)
      {
       ...//logged all parameters
       command.ExecuteNonQuery()
      }
     }
