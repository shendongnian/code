    g.Emit(OpCodes.Ceq);
    g.Emit(OpCodes.Brtrue_S, inequality); // if true goto inequality
    g.Emit(OpCodes.Br_S, equality); // else goto equality
    
    g.MarkLabel(inequality);            
    g.Emit(OpCodes.Ldstr, "Specified strings are different.");
    g.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[]{typeof(string)}));
    g.Emit(OpCodes.Br_S, end); // goto end
    
    g.MarkLabel(equality);
    g.Emit(OpCodes.Ldstr, "Specified strings are same.");
    g.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
    
    g.MarkLabel(end);
    g.Emit(OpCodes.Ret);
