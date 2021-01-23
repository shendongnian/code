        var dm = new DynamicMethod(string.Format("Deserialize{0}", Guid.NewGuid()), typeof(object), new[] { typeof(Document) }, true);
        var il = dm.GetILGenerator();
        var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
        il.DeclareLocal(type);
        il.Emit(OpCodes.Newobj, ctor);
        il.Emit(OpCodes.Stloc_0);
        
        var getFieldValue = typeof(Document).GetMethod("Get", BindingFlags.Instance | BindingFlags.Public);
        var fields = type.GetFields().Where(x => !x.IsStatic);
        foreach (var field in fields)
        {
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldstr, field.Name);
            il.Emit(OpCodes.Callvirt, getFieldValue);
            il.Emit(OpCodes.Stfld, field);
        }
        il.Emit(OpCodes.Ldloc_0);
        il.Emit(OpCodes.Ret);
        return (Func<Document, object>)dm.CreateDelegate(typeof(Func<Document, object>));
