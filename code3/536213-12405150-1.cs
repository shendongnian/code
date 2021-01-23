    static IQueryable<T> Filter<T>(IQueryable<T> col, T filter)
    {
        foreach (var pi in typeof(T).GetProperties())
        {
            if (pi.GetValue(filter) != null)
            {
                var param = Expression.Parameter(typeof(T), "t");
                var body = Expression.Equal(
                    Expression.PropertyOrField(param, pi.Name),
                    Expression.PropertyOrField(Expression.Constant(filter), pi.Name));
                var lambda = Expression.Lambda<Func<T, bool>>(body, param);
                col = col.Where(lambda);
            }
        }
    
        return col;
    }
