    public T Create<T>(T mi, MyVersion myv)
    {
        MyVersionEntity myve = _db.MyVersionEntity.Where(r => r.Id == myv.Id).First();
        Entity<T> mie = new Entity<T>();
        myve.EntityAssoc<T>.Add(mie);
        mie = _updateEntity<T>(mi, mie);
        mi.Id = mie.Id;
        return mi;
    }
