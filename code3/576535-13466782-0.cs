    object[] parameters = CreateParameters(typeof(MyClass<>), "MyMethod", typeof(int));
    Debug.Assert(parameters[0] is int);
    Debug.Assert(parameters[1] is List<int>);
    Debug.Assert(parameters[2] is List<Tuple<int, string>>);
    //...
    object[] CreateParameters(Type type, string methodName, Type genericArgument) {
        object[] parameters = null;
        MethodInfo mInfo = type.GetMethod(methodName);
        if(mInfo != null) {
            var pInfos = mInfo.GetParameters();
            parameters = new object[pInfos.Length];
            for(int i = 0; i < pInfos.Length; i++) {
                Type pType = pInfos[i].ParameterType;
                if(pType.IsGenericParameter)
                    parameters[i] = Activator.CreateInstance(genericArgument);
                if(pType.IsGenericType) {
                    var arguments = ResolveGenericArguments(pType, genericArgument);
                    Type definition = pType.GetGenericTypeDefinition();
                    Type actualizedType = definition.MakeGenericType(arguments);
                    parameters[i] = Activator.CreateInstance(actualizedType);
                }
            }
        }
        return parameters;
    }
    Type[] ResolveGenericArguments(Type genericType, Type genericArgument) {
        Type[] arguments = genericType.GetGenericArguments();
        for(int i = 0; i < arguments.Length; i++) {
            if(arguments[i].IsGenericParameter)
                arguments[i] = genericArgument;
            if(arguments[i].IsGenericType) {
                var nestedArguments = ResolveGenericArguments(arguments[i], genericArgument);
                Type nestedDefinition = arguments[i].GetGenericTypeDefinition();
                arguments[i] = nestedDefinition.MakeGenericType(nestedArguments);
            }
        }
        return arguments;
    }
