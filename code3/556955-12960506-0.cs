    //...
    
    // configuration, maybe factor out to a dedicated class...
    private readonly IDictionary<System.Type, IQueryable> m_SupportedPools =
        new Dictionary<System.Type, IQueryable>();
    
    // add this queryable, note that type inference works here
    public void AddToPool<T>(IQueryable<T> p_Queryable)
    {
        m_SupportedPools.Add(typeof(T), p_Queryable);
    }
    
    public IQueryable<T> GetPool<T>()
    {
        IQueryable t_Set = null;  
        if (m_SupportedQueries.TryGetValue(typeof(T), out t_Set)) {
            return t_Set as IQueryable<T>;
        } else {
            return null;
        }
    }
