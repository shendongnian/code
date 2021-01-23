	public static void IgnoreAllBut<TStructuralType>(
		this StructuralTypeConfiguration<TStructuralType> configuration,
		params Expression<Func<TStructuralType, object>>[] includes)
		where TStructuralType : class
	{
		var includeMembers = ConvertExpressionsToMembers(includes);
		var type = typeof(TStructuralType);
		var properties = type.GetProperties();
		var typeParameter = Expression.Parameter(type);
		var configurationType = configuration.GetType();
		var ignoreMethod = configurationType.GetMethod("Ignore");
		foreach (var property in properties)
		{
			if (!includeMembers.Any(member => member.Name == property.Name))
			{
				var propertyExpression = Expression.Property(typeParameter, property);
				var lambdaExpression = Expression.Lambda(propertyExpression, typeParameter);
				var genericIgnoreMethod = ignoreMethod.MakeGenericMethod(property.PropertyType);
				var parameters = new object[] { lambdaExpression };
				genericIgnoreMethod.Invoke(configuration, parameters);
			}
		}
	}
	private static List<MemberInfo> ConvertExpressionsToMembers<TStructuralType>(
		Expression<Func<TStructuralType, object>>[] expressions)
	{
		var members = new List<MemberInfo>();
		foreach (var lambda in expressions)
		{
			var expression = lambda.Body;
			var memberExpression = expression as MemberExpression;
			if (memberExpression == null)
			{
				var unaryExpression = expression as UnaryExpression;
				memberExpression = unaryExpression.Operand as MemberExpression;
			}
			members.Add(memberExpression.Member);
		}
		return members;
	}
		
