    var dynMethod = new DynamicMethod("", null, new[] { typeof(string) });
    var il = dynMethod.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    var mi = typeof(Console).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null);
    il.Emit(OpCodes.Call, mi);
    il.Emit(OpCodes.Ret);
    var dynDelegate = (Action<string>)dynMethod.CreateDelegate(typeof(Action<string>));
    dynDelegate("test");
