    public IEnumerable<TypeOne> TypeOne
    {
        get { return GetTypes<TypeOne>(); }
    }
    public IEnumerable<TypeTwo> TypeTwo
    {
        get { return GetTypes<TypeTwo>(); }
    }
    
    private IEnumerable<T> GetTypes<T>()
    {
        if (db != null)
        {
            var col = db.Select<T>();
            if (col.Count > 0) return col;
        }
        
        return db2.Select<T>();    
    }
