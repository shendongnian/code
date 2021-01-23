    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string sql = "DELETE From Guests";
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
            sqlCommand.EndExecuteNonQuery();
        }
    }
