    MethodInfo mi1 = typeof(Target3<string, int>).GetMethod("GetTGenericTest");
    MethodInfo mi2 = mi1.DeclaringType.GetGenericTypeDefinition().GetMethod(
        mi.Name,
        (mi.IsStatic ? BindingFlags.Static : BindingFlags.Instance) |
        (mi.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic),
        null,
        mi.GetParameters().Select(p => p.ParameterType).ToArray(),
        null);
