    public Expression<Func<Foo, bool>> GetExpression(int setSize, int[] elements)
    {
        var seedProperty = typeof(Foo).GetProperty("Seed");
    	var parameter = Expression.Parameter(typeof(Foo));
        Expression body = null;
        
        foreach(var element in elements)
        {
            var condition = GetCondition(parameter, seedProperty, setSize, element);
            if(body == null)
    	        body = condition;
            else
                body = Expression.OrElse(body, condition);
        }
        
        return Expression.Lambda<Func<Foo, bool>>(body, parameter);    
    }
    
    public Expression GetCondition(
        ParameterExpression parameter, PropertyInfo seedProperty,
        int setSize, int element)
    {
        return Expression.Equal(
    	    Expression.Modulo(Expression.Property(parameter, seedProperty),
                              Expression.Constant(setSize)),
            Expression.Constant(element));
    }
