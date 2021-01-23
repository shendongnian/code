	public Y<t2> Skip(int count)
	{
		var f = Expression.Call(Expression.Constant(this), "Skip", Type.EmptyTypes, Expression.Constant(count));
		var x = this.Provider.CreateQuery(f);
		return something_else;
	}
