    var path = Assembly.GetAssembly(MyType.GetType()).Location;
    var assembly = Assembly.LoadFrom(path);
    var TypeName = "";
    Type type = thisAssembly.GetType(TypeName);
    object instance = Activator.CreateInstance(type);
  
