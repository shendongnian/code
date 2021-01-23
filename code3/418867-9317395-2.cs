    static DataTable ExecStoredProcedure( string someStoredProcedure , int desiredTableNumber )
    {
      DataTable instance = null ;
      const string credentials = "Data Source=localhost;Initial Catalog=sandbox;Integrated Security=SSPI;" ;
      
      using ( SqlConnection  connection = new SqlConnection( credentials ) )
      using ( SqlCommand     command    = connection.CreateCommand() )
      {
      
        command.CommandType = CommandType.StoredProcedure ;
        command.CommandText = someStoredProcedure ;
        
        connection.Open() ;
        
        using ( SqlDataReader reader = command.ExecuteReader() )
        {
          int i = 0 ;
          while ( reader.HasRows )
          {
          
            // toss any unwanted results ;
            if ( instance != null ) instance.Dispose() ; // toss unwanted results
            
            instance = new DataTable() ;
            instance.Load( reader ) ;
            
            if ( i == desiredTableNumber || reader.IsClosed ) break ;
            
            ++i ;
            
          }
          
          if ( i != desiredTableNumber )
          {
            if ( instance != null ) instance.Dispose() ;
            instance = null ;
          }
          
          // try to tidy up so the connection isn't hose, if we short-circuited execution
          command.Cancel() ;
          reader.Close() ;
          
        }
        
        command.Cancel() ;
        connection.Close() ;
        
      }
      
      return instance ;
    }
