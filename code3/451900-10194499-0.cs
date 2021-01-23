    public static string ForgotPassword ( string username )
    {
        int userid = //Get userid from username
        ForgotPassword(userid);
    }
    
    public static string ForgotPassword ( int username )
    {
        using ( var conn = new SqlConnection( GetConnectionString() ) )
        using ( var cmd = conn.CreateCommand() )
        {
            conn.Open();
            cmd.CommandText =
            @"SELECT 
                 Password 
             FROM 
                 Distributor
             WHERE 
                 DistributorID= @username";
            cmd.Parameters.AddWithValue( "@username", (int)username );
            using ( var reader = cmd.ExecuteReader() )
            {
                if ( !reader.Read() )
                {
                    // no results found
                    return null;
                }
                return reader.GetString( reader.GetOrdinal( "Password" ) );
            }
        }
    }
