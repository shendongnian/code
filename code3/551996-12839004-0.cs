    public static T InvokeMethod<T>(string assemblyName, string namespaceName, string typeName, string methodName, string stringParam)
    {
        // instead of String s = null;
        T methodResult = default(T);
        // instead of s = (String)calledType.InvokeMember(...)
        methodResult = (T)calledType.InvokeMember(...);
        // return s;
        return methodResult;
    }
