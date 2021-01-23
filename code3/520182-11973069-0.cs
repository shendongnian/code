    DynamicMethod dynM = new DynamicMethod(string.Empty, typeof(int), new Type[]{typeof(object)}, typeof(object));
    ILGenerator ilGen = dynM.GetILGenerator(7);
    ilGen.Emit(OpCodes.Ldarg_0);
    ilGen.Emit(OpCodes.Call, typeof(object).GetMethod("GetHashCode"));
    ilGen.Emit(OpCodes.Ret);
    Func<object, int> RootHashCode = (Func<object, int>)dynM.CreateDelegate(typeof(Func<object, int>));
    Console.WriteLine(RootHashCode(null));
