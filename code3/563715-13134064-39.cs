    class Db
    {
        string _connectionString;
        DbProviderFactory _factory;
        public Db(string driver, string connectionString)
        {
            _factory = DbProviderFactories.GetFactory(driver);
            _connectionString = connectionString;
        }
        //and your core function would look like
        IEnumerable<S> Do<R, S>(string query, Action<IDbCommand> parameterizer, 
                                Func<IDbCommand, IEnumerable<R>> actor, 
                                Func<R, S> selector)
        {
            using (var conn = factory.CreateConnection())
            {
                // and all the remaining code..
            }
        }
    }
