    public static bool IsExplicitInterfaceImplementation(MethodInfo method)
    {
        // Check all interfaces implemented in the type that declares
        // the method we want to check, with this we'll exclude all methods
        // that don't implement an interface method
        var declaringType = method.DeclaringType;
        foreach (var implementedInterface in declaringType.GetInterfaces())
        {
            var mapping = declaringType.GetInterfaceMap(implementedInterface);
                    
            // If interface isn't implemented in the type that owns
            // this method then we can ignore it (for sure it's not
            // an explicit implementation)
            if (mapping.TargetType != declaringType)
                continue;
    
            // Is this method the implementation of this interface?
            int methodIndex = Array.IndexOf(mapping.TargetMethods, method);
            if (methodIndex == -1)
                continue;
            // Is it true for any language? Can we just skip this check?
            if (!method.IsFinal || !method.IsVirtual)
                return false;
            // It's not required in all languages to implement every method
            // in the interface (if the type is abstract)
            string methodName = "";
            if (mapping.InterfaceMethods[methodIndex] != null)
                methodName = mapping.InterfaceMethods[methodIndex].Name;
    
            // If names don't match then it's explicit
            if (!method.Name.Equals(interfaceMethodName, StringComparison.Ordinal))
                return true;
        }
    
        return false;
    }
