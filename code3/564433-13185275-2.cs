	IQueryable<T> FilterFunction<T>(IQueryable<T> query)
	{
		ParameterExpression p = Expression.Parameter(typeof(T), "notused");
		Expression<Func<T, bool>> wherePredicate =
		  Expression.Lambda<Func<T, bool>>(
			  Expression.Equal(
				Expression.Call(Expression.Property(p, FilterProperty), "ToString", new Type[0]),
				Expression.Constant(FilterValue)), p);
		return query.Where(wherePredicate);
	}
