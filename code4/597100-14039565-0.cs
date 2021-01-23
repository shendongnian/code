    public IPersister GetPersisterFor(IEntity entity)
    {       
        MethodInfo getPersisterForGenericMethod = 
                        GetType().GetMethods()
                            // iterate over all methods to find proper generic implementation
                            .Single(methodInfo => methodInfo.Name == "GetPersisterFor" && methodInfo.IsGenericMethod)
                            // supply it with generic type parameter
                            .MakeGenericMethod(entity.GetType());
    
        // invoke it
        return getPersisterForGenericMethod.Invoke(this, null) as IPersister;
    }
    
    public IPersister GetPersisterFor<TEntity>() where TEntity : IEntity
    {
        return null;
    }
