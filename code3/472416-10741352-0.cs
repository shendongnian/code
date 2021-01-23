    string CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_TYPE='Base Table'"
    using (SqlConnection sqlConn = new SqlConnection(connectionString))
    {
        sqlConn.Open();
        SqlCommand sqlCmd = new SqlCommand(CommandText, sqlConn);
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
    }
