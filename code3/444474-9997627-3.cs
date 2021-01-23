    object CreateInstance(Type type)
    {
        var method = new DynamicMethod("", typeof(object), Type.EmptyTypes);
        var il = method.GetILGenerator();
        if (type.IsValueType)
        {
            var local = il.DeclareLocal(type);
            // method.InitLocals == true, so we don't have to use initobj here
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Box, type);
            il.Emit(OpCodes.Ret);
        }
        else
        {
            var ctor = type.GetConstructor(Type.EmptyTypes);
            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Ret);
        }
        return method.Invoke(null, null);
    }
