	static void Main()
	{
		var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
			new AssemblyName("foo"), AssemblyBuilderAccess.RunAndSave);
		var module = assemblyBuilder.DefineDynamicModule("foo.dll");
		var aType = module.DefineType(
			"A", TypeAttributes.Public | TypeAttributes.Class);
		var bType = module.DefineType(
			"B", TypeAttributes.Public | TypeAttributes.Class);
		var aCtor = aType.DefineDefaultConstructor(MethodAttributes.Public);
		var bCtor = bType.DefineDefaultConstructor(MethodAttributes.Public);
		CreateMethodM(aType, bType, bCtor);
		CreateMethodM(bType, aType, aCtor);
		aType.CreateType();
		bType.CreateType();
		assemblyBuilder.Save("foo.dll");
	}
	static void CreateMethodM(
		TypeBuilder thisType, Type otherType, ConstructorInfo otherCtor)
	{
		var method = thisType.DefineMethod(
			"M", MethodAttributes.Private, typeof(void), Type.EmptyTypes);
		var il = method.GetILGenerator();
		var local = il.DeclareLocal(otherType);
		il.Emit(OpCodes.Newobj, otherCtor);
		il.Emit(OpCodes.Stloc, local);
		il.Emit(OpCodes.Ret);
	}
