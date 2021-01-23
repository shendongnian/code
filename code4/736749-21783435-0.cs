    var assemblyName = new AssemblyName("TestAssembly");
    var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    var module = assemblyBuilder.DefineDynamicModule("MainModule");
    var typeBuilder = module.DefineType(name: "TestType", attr: TypeAttributes.Public | TypeAttributes.Class);
    // uncommenting this stops the error. Basically, GetTypes() seems to fail if the ModuleBuilder
    // has an "unfinished" type
    //typeBuilder.CreateType();
    module.Assembly.GetTypes();
