    public static List<T> FindEntities<T>(TrackingDataContext dataContext,
        System.Linq.Expressions.Expression<Func<T, bool>> find,
        Func<IQueryable<T>, IQueryable<T>> additonalProcessing = null
    ) where T : class
    {
        var query = dataContext.GetTable<T>().Where(find);
        if(additonalProcessing != null) query = additonalProcessing(query);
        return query.ToList<T>();
    }
