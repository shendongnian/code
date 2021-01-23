    int addUser( string userName )
    {
      if ( string.IsNullOrWhiteSpace(userName) throw new ArgumentException("invalid user name" , "userName") ;
      int user_id ;
      string connectString = GetSomeConnectString() ;
      using ( SqlConnection connection = new SqlConnection( connectString ) )
      using ( SqlCommand    cmd        = connection.CreateCommand() )
      {
        
        cmd.CommandType = CommandType.Text ;
        cmd.CommandText = @"
    insert dbo.user ( user_name ) values ( @user_Name )
    select user_id = @@SCOPE_IDENTITY
    " ;
          
        cmd.Parameters.AddWithValue( "@user_name" , userName ) ;
        connection.Open() ;
        user_id = (int) cmd.ExecuteScalar() ;
        connection.Close() ;
      }
      
      return user_id ;
    }
