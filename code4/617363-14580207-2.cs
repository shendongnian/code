    GetEntity(42);
    GetValue(13);
    public IEntity GetEntity(long id)
    {
        return EntityDao.Get(id);
    }
    
    public IValue GetValue(long id)
    {
        return ValueDao.Get(id);
    }
