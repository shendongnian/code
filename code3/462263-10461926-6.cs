    public TEntity CreateEmpty<TEntity>() 
        where TEntity : IInitializeWithInt, new()
    {
        TEntity obj = new TEntity();
        obj.Initialize(1);
        return obj;
    }
