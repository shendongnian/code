    using(SqlConnection conn = new SqlConnection("connection info"))
    {
       conn.Open();
    
       string sql = "SQL command HERE";
       SqlCommand cmd = new SqlCommand(sql, con);
       SqlDataReader reader = cmd.ExecuteReader();
    ....
    }
