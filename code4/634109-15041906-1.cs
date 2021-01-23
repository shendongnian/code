		// create method
		Type arrayType = typeof(object[]);
		Type intType = typeof(int);
		DynamicMethod dm = new DynamicMethod(methodName, arrayType, new Type[] { intType });
		ILGenerator il = dm.GetILGenerator();
		// create the array -- object[]
		LocalBuilder arr = il.DeclareLocal(arrayType);
		il.Emit(OpCodes.Ldc_I4, 4);
		il.Emit(OpCodes.Newarr, typeof(object));
		il.Emit(OpCodes.Stloc, arr);  // <-- don't use direct addresses, use refs to LocalBuilder instead
		// return the array
		il.Emit(OpCodes.Ldloc, arr); // <-- don't use direct addresses, use refs to LocalBuilder instead
		il.Emit(OpCodes.Ret);
		return dm;
		object result = dm.Invoke(null, new object[] { 1 });
