    static class Program {
      static void Main() {
        A.Instance = (A)FormatterServices.GetUninitializedObject(typeof(A));
 
        var constructor = typeof(A).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
        var helperMethod = new DynamicMethod(string.Empty, typeof(void), new[] { typeof(A) }, typeof(A).Module, true);
        var ilGenerator = helperMethod.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Call, constructor);
        ilGenerator.Emit(OpCodes.Ret);
        var constructorInvoker = (Action<A>)helperMethod.CreateDelegate(typeof(Action<A>));
        constructorInvoker(A.Instance);
 
        Console.WriteLine("A.Instance = (a={0}, b={1})", A.Instance.a, A.Instance.b);
      }
    }
