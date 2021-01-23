    public Expression<Func<Entity, EntityInfo>> materializeEntityInfo =
        e => new EntityInfo { .. };
    public IQueryable<EntityInfo> GetEntities()
    {
        return dbContext.Entities.Select(materializeEntityInfo);
    }
    
