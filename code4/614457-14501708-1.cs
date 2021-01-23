    public IEnumerable<MyDbClass> Get(Func<MyDbClass, bool> func)
    {
        return
            db.MyDbClassEntities.Where(func);
    }
