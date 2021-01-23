    string sql = "insert into tablename (appdate) values (@appdate)";
    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add("@appdate", SqlDbType.DateTime).Value
                = DateTime.Now;
            int rowsInserted = command.ExecuteNonQuery();
            // TODO: Validation of result (you'd expect it to be 1)
        }
    }
