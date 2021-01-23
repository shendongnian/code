    g.Emit(OpCodes.Newobj, typeof(Test).GetConstructor(Type.EmptyTypes));
    g.Emit(OpCodes.Callvirt, typeof(Test).GetMethod("Call", new Type[] { }));
    g.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
              new Type[] { typeof(string) }));
    g.Emit(OpCodes.Ret);
