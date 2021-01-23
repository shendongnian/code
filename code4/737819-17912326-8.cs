    protected void WithConnection<TCxn>(Action<TCxn> sqlBlock) where TCxn : DbConnection, new()
    {
        try
        {
            using (var cxn = new TCxn())
            {
                cxn.ConnectionString = this.ConnectionString;
                cxn.Open();
                sqlBlock(cxn);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"Exception during database connection: {0}", ex);
        }
    }
