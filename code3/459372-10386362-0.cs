    Type t = typeof(MyClass);
    // Determine from which type a class inherits
    Type baseType = t.BaseType;
    // Determine which interfaces a class implements
    Type[] interfaces = t.GetInterfaces();
    // Get fields, properties and methods
    FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    MethodInfo[] methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    foreach (var method in methods) {
        // Get method parameters
        ParameterInfo[] parameters = method.GetParameters();
    }
