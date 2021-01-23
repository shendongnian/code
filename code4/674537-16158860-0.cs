    AppDomain domain = Thread.GetDomain();
    // create a new assembly for the proxy
    AssemblyBuilder assemblyBuilder = 
        domain.DefineDynamicAssembly(
            new AssemblyName("ProxyAssembly"), 
                AssemblyBuilderAccess.Run);
    // create a new module for the proxy
    ModuleBuilder moduleBuilder = 
        assemblyBuilder.DefineDynamicModule("ProxyModule", true);
    // Set the class to be public and sealed
    TypeAttributes typeAttributes = 
        TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed;
    // Construct the type builder
    TypeBuilder typeBuilder = 
        moduleBuilder.DefineType(typeof(TInterface).Name 
        + "Proxy", typeAttributes, channelType);
    List<Type> allInterfaces = new List<Type>(typeof(TInterface).GetInterfaces());
    allInterfaces.Add(typeof(TInterface));
    //add the interface
    typeBuilder.AddInterfaceImplementation(typeof(TInterface));
    //construct the constructor
    Type[] ctorArgTypes = new Type[] { ctorArgType };
    CreateConstructor(channelType, typeBuilder, ctorArgTypes);
    //...
    //construct the method builders from the method infos defined in the interface
    List<MethodInfo> methods = GetAllMethods(allInterfaces);
    foreach (MethodInfo methodInfo in methods)
    {
        MethodBuilder methodBuilder = 
            ConstructMethod(channelType, methodInfo, typeBuilder, 
                ldindOpCodeTypeMap, stindOpCodeTypeMap);
        typeBuilder.DefineMethodOverride(methodBuilder, methodInfo);
    }
    //create the type and construct an instance
    Type t = typeBuilder.CreateType();
    TInterface instance = 
        (TInterface)t.GetConstructor(ctorArgTypes).Invoke(
            new object[] { channelCtorValue });
    return instance;
