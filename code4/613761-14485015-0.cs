    public static MethodInfo CallMethod(MethodInfo[] candicateMethods, object instance, object[] parameters)
    {
        foreach (var method in candicateMethods)
        {
            if (CallMethod(method, instance, parameters))
                return method;
        }
        return null;
    }
    
    private static bool CallMethod(MethodInfo method, object instance, object[] parameters)
    {
        if (method.GetParameters().Length == parameters.Length
            && method.GetParameters()
            .Zip(parameters, (a, b) => new
            {
                Signature = a.ParameterType,
                Candidate = b.GetType()
            })
            .All(pair => pair.Signature.IsAssignableFrom(pair.Candidate)))
        {
            method.Invoke(instance, parameters);
            return true;
        }
        return false;
    }
