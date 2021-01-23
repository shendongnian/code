    public static string InvokeStringMethod5(string assemblyName,
        string namespaceName, string typeName, string methodName, string stringParam)
    {
        string assemblyQualifiedName = string.Format("{0}.{1},{2}",
            namespaceName, typeName, assemblyName);
        Type calledType = Type.GetType(assemblyQualifiedName);
        if(calledType == null) throw new InvalidOperationException(
            assemblyQualifiedName + " not found");
        MethodInfo method = calledType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.Static);
        switch (method.GetParameters().Length)
        {
            case 0:
                return (string)method.Invoke(null, null);
            case 1:
                return (string)method.Invoke(null, new object[] { stringParam });
            default:
                throw new NotSupportedException(methodName
                    + " must have 0 or 1 parameter only");
        }
    }
