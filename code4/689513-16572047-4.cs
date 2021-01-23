    public int insertProfileImage( string playerId , byte[] profileImage , bool pending )
    {
      if ( string.IsNullOrWhiteSpace(playerId) ) throw new ArgumentException("playerId" ) ;
      if ( profileImage == null || profileImage.Length < 1 ) throw new ArgumentException("profileImage") ;
      
      int rowCount ;
      
      string connectString = GetConnectString() ;
      using ( SqlConnection connection = new SqlConnection(connectString) )
      using ( SqlCommand command = connection.CreateCommand() )
      {
        
        command.CommandType = CommandType.StoredProcedure ;
        command.CommandText = "dbo.insertPlayerImage" ;
        
        command.Parameters.AddWithValue( "@playerId"     , playerId            ) ;
        command.Parameters.AddWithValue( "@profileImage" , profileImage        ) ;
        command.Parameters.AddWithValue( "@pending"      , pending ? "Y" : "N" ) ;
        rowCount = command.ExecuteNonQuery() ;
        
      }
      return rowCount ;
    }
