    private static DbDataAdapter CreateAdapter<T>(T a_command) where T: DbCommand
    {
         if (a_command is SqlCommand)
         {
            return new SqlCommand();
         }
    
         // .. others adapters..
    
         return null;
    }
