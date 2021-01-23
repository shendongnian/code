    string sanitized_name;
    using (var sqlCmd = new SqlCommand("select quotename(@unsafe_name, '[');", sqlConn))
    {
        sqlCmd.Parameters.AddWithValue("@unsafe_name", name);
        sanitized_name = (string)sqlCmd.ExecuteScalar();
    }
    using (var sqlCmd = new SqlCommand(string.Format("select next value for {0};", sanitized_name), sqlConn))
    {
        ...
    }
