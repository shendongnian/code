	IQueryable<int> query = new List<int>().AsQueryable<int>();
	IQueryable<int> arg_4D_0 = query;
	ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "x");
	arg_4D_0.Where(Expression.Lambda<Func<int, bool>>(Expression.GreaterThan(parameterExpression, Expression.Constant(0, typeof(int))), new ParameterExpression[]
	{
		parameterExpression
	})).ToList<int>().FirstOrDefault((int x) => x > 10);
