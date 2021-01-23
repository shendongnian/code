		// create method
		Type arrayType = typeof(object[]);
		Type intType = typeof(int);
		DynamicMethod dm = new DynamicMethod(methodName, arrayType, new Type[] { intType });
		ILGenerator il = dm.GetILGenerator();
		// create the array -- object[]
		LocalBuilder arr = il.DeclareLocal(arrayType);
		il.Emit(OpCodes.Ldc_I4, 4);
		il.Emit(OpCodes.Newarr, typeof(object));
		// return the array
		il.Emit(OpCodes.Ret);
		return dm;
		object result = dm.Invoke(null, new object[] { 1 });
