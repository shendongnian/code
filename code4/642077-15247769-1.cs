    object[] parameters = new object[] { null };
    Type typeParam = typeof(string);
    Type ifaceType = typeof(IOut<>).MakeGenericType(typeParam);
    MethodInfo method = ifaceType.GetMethod("Get");
    var impl = new Impl();
    method.Invoke(impl, parameters);
    
    object outParam = parameters[0];
