    g.DeclareLocal(typeof(Test));
    g.Emit(OpCodes.Newobj, typeof(Test).GetConstructor(Type.EmptyTypes));
    g.Emit(OpCodes.Stloc_0);
    g.Emit(OpCodes.Ldloc_0);
    g.Emit(OpCodes.Callvirt, typeof(Test).GetMethod("Call", new Type[] { }));
    g.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
               new Type[] { typeof(string) }));
    g.Emit(OpCodes.Ret);
