	public static IOrderedQueryable<T> OrderByProperty<T>(this IQueryable<T> query, string memberName, bool ascending = true)
	{
		var typeParams = new[] { Expression.Parameter(typeof(T), "") };
		var pi = typeof(T).GetProperty(memberName);
		string operation = ascending ? "OrderBy" : "OrderByDescending";
		return (IOrderedQueryable<T>)query.Provider.CreateQuery(
			Expression.Call(
				typeof(Queryable),
				operation,
				new[] { typeof(T), pi.PropertyType },
				query.Expression,
				Expression.Lambda(Expression.Property(typeParams[0], pi), typeParams))
		);
	}
