    static public Expression<Func<T, bool>> GetComparison<T>(T search)
    {
        var param = Expression.Parameter(typeof(T), "t");
			
        var props = from p in typeof(T).GetProperties()
	                where p.CanRead && !IsDefault(p.GetValue(search, null))
				    select Expression.Equal(
						Expression.Property(param, p.Name),
						Expression.Constant(p.GetValue(search, null))
					);
			
        var expr = props.Aggregate((a, b) => Expression.AndAlso(a, b));
        var lambda = Expression.Lambda<Func<T, bool>>(expr, param);			
        return lambda;
    } 
