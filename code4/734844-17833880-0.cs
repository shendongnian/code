    private static Expression<Func<T, bool>> GetColumnEquality<T>(string property, string term)
    {
        var obj = Expression.Parameter(typeof(T), "obj");        
        
        var objProperty = Expression.PropertyOrField(obj, property);
        var objEquality = Expression.Equal(objProperty, Expression.Constant(term));
        
        var lambda = Expression.Lambda<Func<T, bool>>(objEquality, obj);
    
        return lambda;
    }
    
    public static IQueryable<T> Filter<T>(IQueryable<T> source, string searchTerm)
    {
        var propNames = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                 .Where(e => e.PropertyType == typeof(string))
                                 .Select(x => x.Name).ToList();
    
        var predicate = PredicateBuilder.False<T>();
        
        foreach(var name in propNames)
        {
            predicate = predicate.Or(GetColumnEquality<T>(name, searchTerm));
        }
        
        return source.Where(predicate);
    }
