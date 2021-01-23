    public IEnumerable<T> dbSelect<T>(IEnumerable<T> orDefault = null)
    {
        return db != null
               ? db.Select<T>()
               : orDefault;
    }
    //Later, in your main code...
    IEnumerable<TypeOne> x = dbSelect<TypeOne>(db2.TypeOne);
    IEnumerable<TypeTwo> y = dbSelect<TypeTwo>(db2.TypeTwo);
