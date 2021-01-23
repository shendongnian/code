    public DataTable executeMyStoredProcedure()
    {
      DataTable dt = new DataTable() ;
      string connectString = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;" ;
      
      using ( SqlConnection connection = new SqlConnection(connectString) )
      using ( SqlCommand cmd = connection.CreateCommand() )
      using ( SqlDataAdapter sda = new SqlDataAdapter( cmd ) )
      {
        cmd.CommandText = "dbo.myStoredProcedure" ;
        cmd.CommandType = CommandType.StoredProcedure;
        
        // add your parameters here
        
        sda.Fill( dt ) ;
        connection.Close() ; // redundant, FWIW, since it will be closed via Dispose() when control leaves the using block.
        
      }
      
      return dt ;
    }
