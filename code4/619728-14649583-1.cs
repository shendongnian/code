    public MyEntity GetMyEntity(int entityId, MyContext context)
    {
        MyEntity entity;
        // Get entity from context if it's already loaded.
        entity = context.Set<MyEntity>().Loaded.SingleOrDefault(q => q.EntityId == entityId);
        if (entity != null)
        {
            return entity;
        }
        else if (this.cache.TryGetValue("MYENTITY#" + entityId.ToString(), out entity)
        {
            // Get entity from cache if it's present.  Adapt this to whatever cache API you're using.
            context.Entry(entity).EntityState = EntityState.Unchanged;
            return entity;
        }
        else
        {
            // Load entity if it's not in the context already or in the cache.
            entity = context.Set<MyEntity>().Find(entityId);
            // Add loaded entity to the cache.  Adapt this to specify suitable rules for cache item expiry if appropriate.
            this.cache["MYENTITY#" + entityId.ToString()] = entity;
            return entity;
        }
    }
