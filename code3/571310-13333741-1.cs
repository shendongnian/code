    public static IQueryable<T> GetObjects<T>(this ObjectSet<T> os, 
                                              string fieldName, object value)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var body = Expression.Equal(
            Expression.PropertyOrField(param, fieldName), 
            Expression.Constant(value, value.GetType()));
        var lambda = Expression.Lambda<Func<T, bool>>(body, param);
        return os.Where(lambda);
    }
