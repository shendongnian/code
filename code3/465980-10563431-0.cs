    string sql = "INSERT INTO dbo.YourTable(Col1, ..., ColN) VALUES(@Val1, ..., @ValN); SELECT SCOPE_IDENTITY()";
    using (SqlConnection conn = new SqlConnection(connString))
    using (SqlCommand cmd = new SqlCommand(sql, conn))
    {
        conn.Open();
        _ID = (Int32)cmd.ExecuteScalar();
        conn.Close();
    }
