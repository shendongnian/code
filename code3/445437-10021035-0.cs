    AssemblyName assemblyName = new AssemblyName("TestAssembly");
    AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
    TypeBuilder typeBuilder = moduleBuilder.DefineType("MyClass", TypeAttributes.Public);
    Type entityType = typeof(Entity<>).MakeGenericType(typeBuilder);
    typeBuilder.SetParent(entityType);
    Type t = typeBuilder.CreateType();
