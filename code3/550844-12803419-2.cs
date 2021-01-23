    public IEnumerable<T> dbSelect<T>(IEnumerable<T> orDefault = null)
    {
        return db != null
               ? db.Select<T>()
               : orDefault;
    }
    //...
    IEnumerable<TypeOne> x = dbSelect<TypeOne>(db2.TypeOne);
    IEnumerable<TypeTwo> y = dbSelect<TypeTwo>(db2.TypeTwo);
