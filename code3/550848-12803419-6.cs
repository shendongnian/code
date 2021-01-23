    public IEnumerable<T> dbSelect<T>()
    {
        return db != null
               ? db.Select<T>()
               : db2.Select<T>(); //or db2.GetEntities<T>() or db2.OfType<T> or whatever
    }
    //Later, in your main code...
    var x = dbSelect<TypeOne>();
    var y = dbSelect<TypeTwo>();
