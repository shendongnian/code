    foreach(var e in entityNames)
    {
        PropertyInfo entityProperty = efcontext.GetType().GetProperties().Where(t => t.Name == e).Single();
        var baseQuery = (IQueryable<IMyEntity>)entity.GetValue(efContext, null);
        var result = baseQuery.Where(t => ...);
    }
