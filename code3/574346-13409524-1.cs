	List<MethodInfo> propertyGetterSetters = new List<MethodInfo>();
	foreach(PropertyInfo prop in typeof(MyType).GetProperties())
	{
		var getter = prop.GetGetMethod();
		var setter = prop.GetSetMethod();
		
		if (getter != null)
			propertyGetterSetters.Add(getter);
		
		if (setter != null)
			propertyGetterSetters.Add(setter);
	}
	
	
	List<MethodInfo> nonPropertyMethods = typeof(MyType).GetMethods().Except(propertyGetterSetters).ToList();
