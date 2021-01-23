    using (var connection = new SqlConnection(...))
    {
        using (var reader = QaqcsqlLib.GetSql(connection, "job", "Task1"))
        {
            // Use the reader here
        }
    }
