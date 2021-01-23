    public object CreateObject(Type type)
        {
            var ctor = type.GetConstructor(new Type[]{});
            // Make a NewExpression that calls the ctor with the args we just created
            NewExpression newExp = Expression.New(ctor, null);
            // Create a lambda with the New expression as body and our param object[] as arg
            LambdaExpression lambda = Expression.Lambda(newExp, null);
            // Compile it
            var compiled = lambda.Compile();
            if (compiled != null)
            {
            }
            return compiled.DynamicInvoke();
        }
