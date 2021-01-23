    try with select TOP 1 and ExecuteScalar
    string sql = "Select TOP 1 UserId From User where UserName='Gheorghe'";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        using(SqlCommand cmd = new SqlCommand(sql, conn))
        {
          var result = (Int32)cmd.ExecuteScalar();
        }
    }
