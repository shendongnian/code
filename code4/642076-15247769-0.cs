    object[] parameters = new object[] { null };
    Type typeParam = typeof(string);
    Type ifaceType = typeof(IOut<>).MakeGenericType(typeParam);
    MethodInfo method = ifaceType.GetMethod("Get");
    method.Invoke(impl, parameters);
    
    object outParam = parameters[0];
