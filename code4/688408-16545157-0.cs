    public Expression Eval(Expression expression, string property)
    {
    	var split = property.Split('.');
    	if (split.Length == 1)
    	{
    		return Expression.PropertyOrField(expression, property);
    	}
    	else
    	{
    		return Eval(Expression.PropertyOrField(expression, split[0]), property.Replace(split[0] + ".", ""));
    	}
    }
