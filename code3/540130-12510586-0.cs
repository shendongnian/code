	const string methodSignature = 
		"System.Linq.Expressions.Expression`1[TDelegate] Lambda[TDelegate]" +
		"(System.Linq.Expressions.Expression, System.Linq.Expressions.ParameterExpression[])";
	var lambdaMethod = typeof (Expression).GetMethods()
		.Single(mi => mi.ToString() == methodSignature);
	var funcType = typeof (Func<,>).MakeGenericType(objectType, typeof (object));
	var genericLambda = lambdaMethod.MakeGenericMethod(funcType);
	var selectExpression = genericLambda.Invoke(null, new object[] { expression, new[] { param } });
