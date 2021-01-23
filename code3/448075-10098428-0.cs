        AssemblyName assemblyName = new AssemblyName("MyDynamicAssembly");
        AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly
            (assemblyName, AssemblyBuilderAccess.RunAndSave);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule
            ("MyDynamicAssembly", "MyDynamicAssembly.dll");
        TypeBuilder typeBuilder = moduleBuilder.DefineType
            ("MyDynamicAssembly." + typeName, TypeAttributes.Public, typeof(object));
        typeBuilder.AddInterfaceImplementation(typeof(IMyInterface)); 
        typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
