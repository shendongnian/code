    Assembly assembly = Assembly.LoadFile(@"assembly location");	// you can change the way you load the assembly
    Type type = assembly.GetType("mynamespace.NameOfTheClass");                                       
    ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
    object classObject = constructor.Invoke(new object[] { });
    
    MethodInfo methodInfo = type.GetMethod("GetDetails");
    var returnValue = (List<customType>)methodInfo.Invoke(classObject, new object[] { param1});
