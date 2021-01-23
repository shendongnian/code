		public static void Test()
		{
			var deps = RegisterDependencies((KeyValuePair<string,string> p) => p.Key, (KeyValuePair<string,string> p) => p.Value);
			foreach(var d in deps)
			{
				Console.WriteLine(d); // Prints Key, Then Value
			}
		}
		public static IEnumerable<string> RegisterDependencies<T>(Expression<Func<T, object>> property,    params Expression<Func<T, object>>[] dependencies)
		{
			var deps = new List<string>();
			deps.Add(GetPropertyName(property));
			foreach (var d in dependencies)
			{
				deps.Add(GetPropertyName(d));
			}
			return deps;
		}
	
		public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
		{
			var lambda = expression as LambdaExpression;
		
			MemberExpression memberExpression;
			if (lambda.Body is UnaryExpression)
			{
				var unaryExpression = lambda.Body as UnaryExpression;
				memberExpression = unaryExpression.Operand as MemberExpression;
			}
			else
			{
				memberExpression = lambda.Body as MemberExpression;
			}
		
			return memberExpression != null ? ((PropertyInfo)memberExpression.Member).Name : null;
		}
