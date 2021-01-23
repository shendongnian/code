    public static EntityKey GetEntityKey<T>(this DbContext context, T entity)
        where T : class
    {
        var oc = ((IObjectContextAdapter)context).ObjectContext;
        ObjectStateEntry ose;
        if (null != entity && oc.ObjectStateManager
                                .TryGetObjectStateEntry(entity, out ose))
        {
            return ose.EntityKey;
        }
        return null;
    }
    
    public static EntityKey GetEntityKey<T>( this DbContext context
                                           , DbEntityEntry<T> dbEntityEntry)
        where T : class
    {
        if (dbEntityEntry != null)
        {
            return GetEntityKey(context, dbEntityEntry.Entity);
        }
        return null;
    }
