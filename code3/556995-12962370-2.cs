    // read property names from file
    string[] propertyNames = { "MyTestProperty1", "MyTestProperty2" };
    
    AssemblyName name = new AssemblyName("Foo");
    AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain
       .DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("Bar");
    TypeBuilder typeBuilder = 
       moduleBuilder.DefineType("MyTestClass", TypeAttributes.Public);
    
    foreach (var propertyName in propertyNames)
    {
        PropertyBuilder property = typeBuilder.DefineProperty(
             propertyName,
             System.Reflection.PropertyAttributes.HasDefault, 
             typeof(string), 
             null);        
        MethodBuilder getter = typeBuilder.DefineMethod(
             "get_" + propertyName,
             MethodAttributes.Public | MethodAttributes.SpecialName, 
             typeof(string), 
             Type.EmptyTypes);
        ILGenerator generator = getter.GetILGenerator();
        // generate default value for property
        generator.Emit(OpCodes.Ldstr, propertyName.Replace("Property", " "));
        generator.Emit(OpCodes.Ret);
        property.SetGetMethod(getter);
    }
    Type type = typeBuilder.CreateType();
