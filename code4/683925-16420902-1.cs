    var targetMethod = Assembly.LoadFrom("ThirdPartyLibrary.dll")
        .GetType("ThirdPartyLibrary.MyPrint")
        .GetMethod("Print", new [] {typeof(string)});
    ...
    il.Emit(OpCodes.Ldstr, "Test!");
    il.Emit(OpCodes.Call, targetMethod);
    il.Emit(OpCodes.Ret);
