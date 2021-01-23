    static void Main( string[] args )
    {
       Func<SqlConnection> getConnection =
                () =>
                   {
                      var connection =
                         new SqlConnection(
                            "Initial Catalog=myDatabase;Server=(local);Username=bogus;password=blah;Connect Timeout=10;" );
                      connection.Open();
                      return connection;
                   };
       while(true)
       {
          try
          {
             using( var connection = getConnection() )
             {
                var cmd = new SqlCommand( "SELECT 1", connection ) {CommandType = CommandType.Text};
                cmd.ExecuteNonQuery();
             }
          }
          catch ( Exception )
          {
             // ignore exception
          }
       }
    }
