    Type argument = GetGenericArgument(typeof(MyList), typeof(IList<>));
    //...
    static Type GetGenericArgument(Type type, Type genericTypeDefinition) {
        Type[] interfaces = type.GetInterfaces();
        for(int i = 0; i < interfaces.Length; i++) {
            if(!interfaces[i].IsGenericType) continue;
            if(interfaces[i].GetGenericTypeDefinition() == genericTypeDefinition)
                return interfaces[i].GetGenericArguments()[0];
        }
        return null;
    }
