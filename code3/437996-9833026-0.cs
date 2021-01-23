    var property = typeof(BaseClass)
        .GetProperty("Wrapped", BindingFlags.Instance | BindingFlags.NonPublic);
    var il = method.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Call, property.GetGetMethod(true));
    for (var i = 0; i < baseMethod.GetParameters().Length; ++i)
        il.Emit(OpCodes.Ldarg_S, i + 1);
    il.Emit(OpCodes.Call, baseMethod);
    il.Emit(OpCodes.Ret);
