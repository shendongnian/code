	var getMethodBuilder = typeBuilder.DefineMethod(
		"get_" + upperName, MethodAttributes.Public, typeof(int), Type.EmptyTypes);
	var il = getMethodBuilder.GetILGenerator();
	il.Emit(OpCodes.Ldc_I4, defaultValue);
	il.Emit(OpCodes.Ret);
	var propertyBuilder = typeBuilder.DefineProperty(
		upperName, PropertyAttributes.None, typeof(int), Type.EmptyTypes);
	propertyBuilder.SetGetMethod(getMethodBuilder);
