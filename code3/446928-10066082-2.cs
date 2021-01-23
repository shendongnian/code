       //SQL string to count the amount of rows within the OSDE_Users table 
        string sql = "SELECT * FROM RSSFeeds where URL = @URL"; 
    DataSet ds = new DataSet(); 
        using(SqlConnection cnn = Connect())
        using(SqlCommand cmd = new SqlCommand(sql, cnn)) 
        {
            cmd.Parameters.Add("@URL", SqlDbType.VarChar, 500).Value = url; 
            using(SqlDataAdapter adapt = new SqlDataAdapter(cmd))
            {
             
                adapt.Fill(ds); 
            }
        }
        return ds; 
