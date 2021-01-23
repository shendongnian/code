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
    
    private static IEnumerable<Expression> CreateParameterExpressionsWithAnyCallback(IEnumerable<Expression> oldParameterExpressions, IEnumerable<object> parameterValues)
	{
		// Assume the last parameter is the callback.
		var callbackParamExpr = oldParameterExpressions.Last();
		return oldParameterExpressions.Zip(parameterValues, (paramExpr, paramVal) =>
			{
				if(paramExpr != callbackParamExpr)
				{
					return Expression.Constant(paramVal, paramExpr.Type) as Expression;
				}
				else
				{
					var isAnyCallback = typeof(Moq.It).GetMethod("IsAny").MakeGenericMethod(paramExpr.Type);
					return Expression.Call(null, isAnyCallback) as Expression;
				}
			});
	}
