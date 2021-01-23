    interface IDb
    {
        int Add(string query, Action<IDbCommand> parameterizer);
        int Save(string query, Action<IDbCommand> parameterizer);
        int SaveSafely(string query, Action<IDbCommand> parameterizer);
        IEnumerable<T> Get<T>(string query, Action<IDbCommand> parameterizer, 
                              Func<IDataRecord, T> selector);
    }
