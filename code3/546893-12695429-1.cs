    public IEnumerable<MyObjectType> Get(int id, string format)
    {
        using (db = new DbEntities())
        {
           return db.pr_ApiSelectMyObjectType(store, id, format)
                    .AsEnumerable();
        }
    }
