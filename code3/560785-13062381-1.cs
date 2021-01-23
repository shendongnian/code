    string query = "...(whatever you need).....";
 
    using(SqlCeConnection conn = new SqlCeConnection(connectionString))
    using(SqlCeCommand cmd = new SqlCeCommand(query, conn))
    { 
        // just add parameters directly to SqlCeCommand object .... 
        cmd.Parameters.Add("username", Username);
        cmd.Parameters.Add("password", Password);
        conn.Open();
        cmd.ExecuteNonQuery();  // or whatever you need to do 
        conn.Close();
    }
