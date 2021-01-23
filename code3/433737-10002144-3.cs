    public static void ArrangeDataPortalResult<TMocked, TResult, TParam>(Mock<TMocked> mock, Expression<Action<TParam, EventHandler<DataPortalResult<TResult>>>> expectedMethodCall, TParam parameter, TResult result)
		where TMocked : class
	{
		var methodCallExpr = expectedMethodCall.Body as MethodCallExpression;
		var newMethodCallExpr = TransformAsyncCallForMoq<TMocked, TResult>(methodCallExpr, parameter);
		mock.Setup(newMethodCallExpr)
			.Callback<TParam, EventHandler<DataPortalResult<TResult>>>((p, callback) => callback(null, new DataPortalResult<TResult>(result, null, null)));
	}
    
    private static Expression<Action<TMocked>> TransformAsyncCallForMoq<TMocked, TResult>(MethodCallExpression methodCallExpr, params object[] expectedParameterValues)
	{
		var methodCallParameters = methodCallExpr.Arguments;
		/// Transform a method call on a specific object,
		/// e.g. (param1, param2, callback) => MyMockObject.GetData(param1, param2, callback),
		/// into a lambda expression that Moq's Setup method can use, which looks more like this:
		/// m => m.GetData(5, "asdf", /* any event handler */).
		MethodCallExpression newMethodCallExpression = Expression.Call(
			Expression.Parameter(typeof(TMocked), "m"),
			methodCallExpr.Method,
			CreateParameterExpressionsWithAnyCallback(methodCallParameters, expectedParameterValues));
		return Expression.Lambda<Action<TMocked>>(newMethodCallExpression, Expression.Parameter(typeof(TMocked), "m"));
	}
    
    private static IEnumerable<Expression> CreateParameterExpressionsWithAnyCallback(IEnumerable<Expression> oldParameterExpressions, IEnumerable<object> expectedParameterValues)
	{
        // Given a set of expressions and expected values, returns a new set of expressions that will 
		// allow Moq to set the proper method call expectation. Assumes there will be one more parameter
		// expression (the callback parameter) that has no expected value, and allows any value for it.
    
		var newParameterExpressions = oldParameterExpressions.Zip(expectedParameterValues,
			(paramExpr, paramVal) => Expression.Constant(paramVal, paramExpr.Type) as Expression);
		foreach (var expr in newParameterExpressions)
		{
			yield return expr;
		}
		var callbackParamExpr = oldParameterExpressions.Last();
		var isAny = typeof(Moq.It).GetMethod("IsAny").MakeGenericMethod(callbackParamExpr.Type);
		yield return Expression.Call(null, isAny) as Expression;
	}
