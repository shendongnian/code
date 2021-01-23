    public static Func<TType, TResult> CreateExpression<TType, TResult>(string propertyName) 
    {
    	Type type = typeof(TType);
    	ParameterExpression parameterExpression = Expression.Parameter(type, propertyName);
    	MemberInfo property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    	MemberExpression valueInProperty =  Expression.MakeMemberAccess(parameterExpression, property);
    
    	return Expression.Lambda<Func<TType,TResult>>(valueInProperty, parameterExpression).Compile();
    }
