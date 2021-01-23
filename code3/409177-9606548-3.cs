    AssemblyName asmName = new AssemblyName(
        string.Format("{0}_{1}", "tmpAsm", Guid.NewGuid().ToString("N"))
    );
    
    // create in memory assembly only
    AssemblyBuilder asmBuilder =
        AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
    
    ModuleBuilder moduleBuilder =
        asmBuilder.DefineDynamicModule("core");
    
    string proxyTypeName = string.Format("{0}_{1}", repositoryInteface.Name, Guid.NewGuid().ToString("N"));
    
    TypeBuilder typeBuilder = 
        moduleBuilder.DefineType(proxyTypeName);
                
    typeBuilder.AddInterfaceImplementation(repositoryInteface);
    typeBuilder.SetParent(repository);
    
    Type proxy = typeBuilder.CreateType();
