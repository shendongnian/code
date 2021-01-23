    public IEnumerable<TypeOne> TypeOne
    {
        get { return GetTable<TypeOne>(); }
    }
    public IEnumerable<TypeTwo> TypeTwo
    {
        get { return GetTable<TypeTwo>(); }
    }
    
    private IEnumerable<T> GetTable<T>()
    {
        if (db != null)
        {
            var col = db.Select<T>();
            if (col.Count > 0) return col;
        }
        
        return db2.Select<T>();    
    }
