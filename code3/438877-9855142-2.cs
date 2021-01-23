	private static IEnumerable<Type> GetDerivedTypesFor(Type baseType)
	{
		var assembly = Assembly.GetExecutingAssembly();
		return assembly.GetTypes()
			.Where(baseType.IsAssignableFrom)
			.Where(t => baseType != t);
	}
