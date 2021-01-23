    private static MethodInfo GetInterfaceMethod(Type implementingClass, Type implementedInterface, MethodInfo classMethod)
    {
        var map = implementingClass.GetInterfaceMap(implementedInterface);
        var index = Array.IndexOf(map.TargetMethods, classMethod);
        return map.InterfaceMethods[index];
    }
