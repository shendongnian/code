    using (var sqlConnection = new SqlConnection("...connection string...")
    {
        sqlConnection.Open();
        var sqlCommand = sqlConnection.CreateCommand();
        ...
    }
