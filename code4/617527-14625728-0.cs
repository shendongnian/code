    public override IQueryable GetQueryable(IQueryable source)
    {
    	if (string.IsNullOrEmpty(textBox.Text))
    	{
    		return source;
    	}
    	
    	string filterValue = textBox.Text;
    	ConstantExpression value = Expression.Constant(filterValue);
    	
    	ParameterExpression parameter = Expression.Parameter(source.ElementType);
    	MemberExpression property = Expression.Property(parameter, Column.Name);
    	if (Nullable.GetUnderlyingType(property.Type) != null)
    	{
    		property = Expression.Property(property, "Value");
    	}
    
    	Expression comparison = Expression.Call(property, typeof(string).GetMethod("Contains", new [] { typeof(string) }), value);
    	LambdaExpression lambda = Expression.Lambda(comparison, parameter);
    	
    	MethodCallExpression where = Expression.Call(
    		typeof(Queryable),
    		"Where",
    		new[] { source.ElementType },
    		source.Expression,
    		lambda);
    
    	return source.Provider.CreateQuery(where);
    }
