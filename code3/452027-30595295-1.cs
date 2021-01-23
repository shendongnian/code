    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TableName;";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                strCol1 = reader.GetValue(0).ToString();
            }
            reader.Close();
      }
      conn.Close();
    }
