    public static object InvokeMethod(object o, string MethodName, object[] parameters)
    {
        // get the types of the params
        List<Type> paramTypes = new List<Type>();
        foreach (object p in parameters)
        {
            paramTypes.Add(p.GetType());
        }
        try
        {
            // get the method, equal to the parameter types
            MethodInfo methodInfo = o.GetType().GetMethod("MethodNameAsString", paramTypes.ToArray());
            // and invoke the method with your parameters
            return methodInfo.Invoke(o, parameters);
        }
        catch (MissingMethodException e)
        {
            // discard or do something
        }
    }
