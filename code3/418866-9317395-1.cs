    static DataSet[] ExecStoredProcedure()
    {
      DataSet[] instance = null ;
      const string credentials = "Data Source=localhost;Initial Catalog=sandbox;Integrated Security=SSPI;" ;
          
      using ( SqlConnection  connection = new SqlConnection( credentials ) )
      using ( SqlCommand     command    = connection.CreateCommand() )
      using ( SqlDataAdapter adapter    = new SqlDataAdapter( command ) )
      using ( DataSet        results    = new DataSet() )
      {
            
        command.CommandType = CommandType.StoredProcedure ;
        command.CommandText = @"someStoredProcedure" ;
            
        connection.Open() ;
        adapter.Fill( results ) ;
        connection.Close() ;
            
        List<DataSet> list = new List<DataSet>( results.Tables.Count ) ;
        while ( results.Tables.Count > 0 )
        {
          DataTable dt = results.Tables[0] ;
              
          results.Tables.RemoveAt(0) ;
          DataSet ds = new DataSet() ;
          ds.Tables.Add( dt ) ;
          list.Add(ds) ;
              
        }
            
        instance = list.ToArray() ;
      
      }
      
      return instance ;
    }
