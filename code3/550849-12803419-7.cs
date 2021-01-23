    public IEnumerable<T> dbSelect<T>() //may need type constraints here
    {
        return db != null
               ? db.Select<T>()
               : null;
    }
    public IEnumerable<TypeOne> TypeOne
    {
        get { return dbSelect<TypeOne> ?? db2.TypeOne; }
    }
    public IEnumerable<TypeTwo> TypeTwo
    {
        get { return dbSelect<TypeTwo>() ?? db2.TypeTwo; }
    }
