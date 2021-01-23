    private static Func<object, object, object> GenAddFunc(Type elementType)
    {
    	var param1Expr = Expression.Parameter(typeof(object));
    	var param2Expr = Expression.Parameter(typeof(object));
    	var addExpr = Expression.Add(Expression.Convert(param1Expr, elementType), Expression.Convert(param2Expr, elementType));
    	return Expression.Lambda<Func<object, object, object>>(Expression.Convert(addExpr, typeof(object)), param1Expr, param2Expr).Compile();
    }
    
    IEnumerable<object> listValues;
    Type elementType = listValues.First().GetType();
    var addFunc = GenAddFunc(elementType);
    
    object sum = listValues.Aggregate(addFunc);
