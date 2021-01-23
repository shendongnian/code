    public IQueryable<T> GetQueryable<T>()
    {
       //Implementation depends on your data provider
       //return dataContext.GetTable<T>();
       //return session.Query<T>();
    }
