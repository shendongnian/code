    IEnumerable<BusinessObject> list = new List<BusinessObject>() ;
    using ( SqlConnection  connection = new SqlConnection( credentials ) )
    using ( SqlCommand     command    = connection.CreateCommand() )
    using ( SqlDataAdapter adapter    = new SqlDataAdapter( command ) )
    using ( DataSet        results    = new DataSet() )
    {
      
      command.CommandType = CommandType.StoredProcedure ;
      command.CommandText = @"someStoredProcedure" ;
      
      try
      {
        connection.Open() ;
        adapter.Fill( results ) ;
        connection.Close() ;
        list = TransformResults( results ) ;
      }
      catch
      {
        command.Cancel() ;
        throw
      }
 
    }
    return list ;
