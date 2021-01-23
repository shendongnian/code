	ParameterExpression employeesParameter = Expression.Parameter(typeof(Employee), "e");
	MemberExpression subordinatesProperty = Expression.Property(employeesParameter, typeof(Employee).GetProperty("Subordinates"));
	MethodCallExpression hasSubordinates = Expression.Call(typeof(Enumerable),
		"Any",
		new Type[] { typeof(Employee) },
		subordinatesProperty);
	LambdaExpression whereLambda = Expression.Lambda(hasSubordinates, employeesParameter);
	MethodCallExpression whereExpression = Expression.Call(typeof(Queryable),
		"Where",
		new Type[] { typeof(Employee) },
		Expression.Constant(dataContext.Employees),
		whereLambda);
