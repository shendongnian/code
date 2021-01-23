    protected void WithConnection(Action<DbConnection> sqlBlock, Func<string, DbConnection> dbCxnFactory)
    {
        try
        {
            using (DbConnection connection = dbCxnFactory(this.ConnectionString))
            {
                connection.Open();
                sqlBlock(connection);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"Exception during database connection: {0}", ex);
        }
    }
