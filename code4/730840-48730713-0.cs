    public virtual void Delete<T>(int id) where T : BaseEntity, new()
    {
    	T instance = Activator.CreateInstance<T>();
    	instance.Id = id;
    	if (dbContext.Entry<T>(entity).State == EntityState.Detached)
    	{
    		dbContext.Set<T>().Attach(entity);
    	}
    	
    	dbContext.Set<T>().Remove(entity);
    }
