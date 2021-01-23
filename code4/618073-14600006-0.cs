    public DoWorkOnDb(Func<SqlConnection> connectionFactory)
    {
        using (var connection = connectionFactory())
        {
            // ...
        }
    }
