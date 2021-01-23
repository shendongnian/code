    _connection =
        new SqlConnection(connectionString);
    try
    {
        _connection.Open();
    }
    catch (InvalidOperationException)
    {
        SqlConnection.ClearAllPools();
        _connection.Open();
    }
