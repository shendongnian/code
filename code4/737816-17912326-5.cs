    protected void WithConnection<T>(Action<T> sqlBlock, Func<T> dbCxnFactory) where T : DbConnection
    {
        try
        {
            using (T connection = dbCxnFactory())
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
