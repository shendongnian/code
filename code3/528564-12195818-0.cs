    ilgen.EmitCall(OpCodes.Call, callMeth, null);
    if (method.ReturnType != null && method.ReturnType != typeof(void))
    {
        ilgen.Emit(OpCodes.Stloc_0);
        Label end = ilgen.DefineLabel();
        ilgen.Emit(OpCodes.Br_S, end);
        ilgen.MarkLabel(end);
        ilgen.Emit(OpCodes.Ldloc_0);
    }
    ilgen.Emit(OpCodes.Ret);
