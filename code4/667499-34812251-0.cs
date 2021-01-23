    static MethodInfo Resolve (Type type)
    {
        Expression<Action<MyClass<object>, object>> lambda = (c, a) => c.MyMethod (a);
        MethodCallExpression                        call = lambda.Body as MethodCallExpression;
        MethodInfo[]                                methods;
        Type                                        target;
    
        target = call
            .Method // Get MethodInfo for MyClass<object>.MyMethod
            .DeclaringType // Get typeof (MyClass<object>)
            .GetGenericTypeDefinition () // Get typeof (MyClass<>)
            .MakeGenericType (type); // Get typeof (MyClass<T>) where typeof (T) == type
    
        methods = target.GetMethods (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static); // We probably don't need static methods
    
        return Array.Find (methods, (m) => m.MetadataToken == method.MetadataToken); // Find MyClass<T>.MyMethod where typeof (T) == type
    }
