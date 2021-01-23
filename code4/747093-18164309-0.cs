    private Expression<Func<object[], Expression<Func<C1Source, bool>>>> CreateKeyExpression<C1Source>()
    {
        ParameterExpression instanceParameter = Expression.Parameter(typeof(C1Source));
        ParameterExpression keyParameters = Expression.Parameter(typeof(object[]));
        PropertyInfo[] objectKeys = typeof(C1Source).GetKeyProperties().ToArray();
        var expr = Expression.Equal( Expression.Property(instanceParameter,objectKeys[0]),
         Expression.Convert( 
            Expression.ArrayIndex(keyParameters,Expression.Constant(0)),
            objectKeys[0].PropertyType)
            ); 
        for (int i = 1; i < objectKeys.Length; i++)
		{
			expr = Expression.AndAlso(expr, Expression.Equal(
                Expression.Property(instanceParameter,objectKeys[i]),
                Expression.Convert(
                    Expression.ArrayIndex(keyParameters,Expression.Constant(i)),
                    objectKeys[i].PropertyType)
                    ); 
		}
        var lmp= Expression.Lambda(expr, instanceParameter);
        return Expression.Lambda<Func<object[], Expression<Func<C1Source, bool>>>>(lmp, keyParameters);
    
    }
