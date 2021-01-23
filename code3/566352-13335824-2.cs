	public static IEnumerable<PropertyInfo> GetAllProperties(this TypeInfo type)
	{
		var list = type.DeclaredProperties.ToList();
		var subtype = type.BaseType;
		if (subtype != null)
			list.AddRange(subtype.GetTypeInfo().GetAllProperties());
		return list.ToArray();
	}
