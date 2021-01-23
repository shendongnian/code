    var sql =
    @"INSERT <Your Data> <Your Table>;
    SELECT SCOPE_IDENTIY();"
    using (SqlConnection connection = new SqlConnection(strConnection))
    {
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            connection.Open();
            object result = command.ExecuteScalar();
        }
    }
    int? id = (int?)(!Convert.IsDBNull(result) ? result : null);
