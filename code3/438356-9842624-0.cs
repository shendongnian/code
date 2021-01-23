        object provider = …;
        object predicate = predicateProperty.GetValue(
            invocation.InvocationTarget, null);
        var getMethod = provider.GetType().GetMethod("Get");
        object item = getMethod.Invoke(provider, new[] { predicate });
