	private bool IsSuperClassOfSomeKindOfSuperDataClass(Type type)
	{
		if (!type.IsGenericType)
			return false;
		var gtd = type.GetGenericTypeDefinition();
		if (gtd != typeof(SuperClass<>))
			return false;
		var genericParameter = type.GetGenericArguments().First();
		return genericParameter.IsSubclassOf(typeof(SuperDataClass));
	}
