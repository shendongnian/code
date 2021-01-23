    if (!r.Read())
    {
       SqlCommand c = new System.Data.SqlClient.SqlCommand("insert into dic values(@k)", con2); ;
       c.Parameters.AddWithValue("@k", english_w); // c instead of mssql_cmnd
       c.ExecuteNonQuery();
    }
