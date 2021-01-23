    Type t = typeof(MyClass);
    // Determine from which type a class inherits
    Type baseType = t.BaseType;
    // Determine which interfaces a class implements
    Type[] interfaces = t.GetInterfaces();
    // Get fields, properties and methods
    const BindingFlags bindingFlags =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    FieldInfo[] fields = t.GetFields(bindingFlags);
    PropertyInfo[] properties = t.GetProperties(bindingFlags);
    MethodInfo[] methods = t.GetMethods(bindingFlags);
    foreach (var method in methods) {
        // Get method parameters
        ParameterInfo[] parameters = method.GetParameters();
    }
