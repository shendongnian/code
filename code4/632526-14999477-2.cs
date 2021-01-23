    List<object> _newEntities;
    private override OnCommit()
    {
        foreach(var newEntity in newEntities)
            DatabaseContext.Entry(newEntity).State = EntityState.Added;
    }
    public virtual T InsertOrUpdate<T>(T entity) where T : class
    {
        var databaseEntity = this.GetEntityByPrimaryKey(entity);
        if (databaseEntity == null)
            _newEntities.Add(entity);
        else
            this.DatabaseContext.Entry(databaseEntity).CurrentValues.SetValues(entity);
        return databaseEntity;
    }
