    public bool IsValid(string username, string password)
            {
                string connectionString = @"...connectionstring";
                
    
                string SQL = "SELECT * FROM UserAccounts where [Username]='" + username + "' and [Password]='" + password + "'";
    
                OdbcConnection conn = new OdbcConnection(connectionString);
    
                OdbcCommand cmd = new OdbcCommand(SQL);
                cmd.Connection = conn;
    
                conn.Open();
    
                OdbcDataReader reader = cmd.ExecuteReader();
    
                if (reader.HasRows)
                {
                    return true;
                }
    
                return false;
            }
