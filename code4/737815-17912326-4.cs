    protected void WithConnection(Action<DbConnection> sqlBlock, Func<DbConnection> dbCxnFactory)
    {
        try
        {
            using (DbConnection connection = dbCxnFactory())
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();
                sqlBlock(connection);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"Exception during database connection: {0}", ex);
        }
    }
