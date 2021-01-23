    MethodInfo genericMethodDefinition = GetType()
        .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
        .Where(method => method.IsGenericMethod && method.Name == "GetPersisterFor")
        .First();
    // OR
    MethodInfo genericMethodDefinition = GetType().GetMethod("GetPersisterFor",
        BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
    // THEN
    MethodInfo genericMethod = genericMethodDefinition.MakeGenericMethod(entity.GetType());
    genericMethod.Invoke(this, null);
