    g.DeclareLocal(typeof(Object));
    g.Emit(OpCodes.Newobj, typeof(Test).GetConstructor(Type.EmptyTypes));
    g.Emit(OpCodes.Stloc, 0);
    g.Emit(OpCodes.Ldloc, 0);
    g.Emit(OpCodes.Castclass, typeof(Test));
    g.Emit(OpCodes.Callvirt, typeof(Test).GetMethod("Call", new Type[] { }));
    g.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
           new Type[] { typeof(string) }));
    g.Emit(OpCodes.Ret);
