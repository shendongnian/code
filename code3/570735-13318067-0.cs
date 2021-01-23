    static bool IsAuthenticated( string uid , string pwd )
    {
        if ( string.IsNullOrWhiteSpace(uid) ) throw new ArgumentNullException("uid") ;
        if ( string.IsNullOrWhiteSpace(pwd) ) throw new ArgumentNullException("pwd") ;
            
        bool authenticated ;
            
        using ( SqlConnection cn = new SqlConnection("Data source=(local); Initial Catalog=INT422Assignment1; Integrated Security=SSPI;") )
        using ( SqlCommand    cmd = cn.CreateCommand() )
        {
                
            cmd.CommandType = CommandType.Text ;
            cmd.CommandText = @"
    SELECT authenticated = count(*)
    FROM myLogin
    WHERE userNameTB = @username
    AND passWordTB = @pwd"
            ;
                
            cmd.Parameters.AddWithValue( "@username" , uid ) ;
            cmd.Parameters.AddWithValue( "@pwd"      , pwd ) ;
                
            cn.Open() ;
                
            authenticated = ((int)cmd.ExecuteScalar()) > 0 ? true : false ;
        cmd.ExecuteNonQuery();
                
            cn.Close() ;
                
        }
            
        return authenticated ;
            
    }
