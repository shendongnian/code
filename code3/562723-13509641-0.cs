	// Gets the AssemblyDefinition (similar to .Net's Assembly).
	Type testType = typeof(MyClass<>);
	AssemblyDefinition assemblyDef = AssemblyDefinition.ReadAssembly(new Uri(testType.Assembly.CodeBase).LocalPath);
	// Gets the TypeDefinition (similar to .Net's Type).
	TypeDefinition classDef = assemblyDef.MainModule.Types.Single(typeDef => typeDef.Name == testType.Name);
	// Gets the MethodDefinition (similar to .Net's MethodInfo).
	MethodDefinition myMethodDef = classDef.Methods.Single(methDef => methDef.Name == "Foo");
