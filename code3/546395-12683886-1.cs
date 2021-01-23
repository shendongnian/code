    public void DoFooWith(object blob)
    {
        // Get the containing class
        var utilType = typeof(Util);
        // Get the method we want to invoke
        var baseMethod = utilType.GetMethod("Foo", new Type[]{typeof(object)});
        // Get a "type-specific" variant
        var typedForBlob = baseMethod.MakeGenericMethod(blob.GetType());
        // And invoke it
        var res = typedForBlob.Invoke(null, new[]{blob});
    }
