    ParameterExpression employeesParameter = Expression.Parameter(typeof(Employee), "e");
    MemberExpression subordinatesProperty = Expression.Property(employeesParameter, typeof(Employee).GetProperty("Subordinates"));
	var mi = typeof(Enumerable).GetMethods().First(x => x.Name == "Any" && x.GetParameters().Length == 1);
	mi = mi.MakeGenericMethod(typeof (bool));
	var hasSubordinates = Expression.Call(mi, subordinatesProperty);
