    private delegate object CreateObject();
    private delegate Rectangle CreateRectangle();
    static void Main()
    {
      Console.WriteLine(new Rectangle());
      Console.WriteLine();
      TryCreateDelegate<CreateObject>(BuildDynamicMethod_Boxed());
      Console.WriteLine();
      TryCreateDelegate<CreateRectangle>(BuildDynamicMethod());
      Console.WriteLine();
    }
    private static DynamicMethod BuildDynamicMethod_Boxed()
    {
      var TRect = typeof(Rectangle);
      var dm = new DynamicMethod("buildNewRectangle", typeof(object), Type.EmptyTypes);
      var il = dm.GetILGenerator();
      il.Emit(OpCodes.Ldloca_S, il.DeclareLocal(TRect));
      il.Emit(OpCodes.Initobj, TRect);
      il.Emit(OpCodes.Ldloc_0);      
      il.Emit(OpCodes.Box, TRect);
      il.Emit(OpCodes.Ret);
      return dm;
    }
    private static DynamicMethod BuildDynamicMethod()
    {
      var TRect = typeof(Rectangle);
      var dm = new DynamicMethod("buildNewRectangle", TRect, Type.EmptyTypes);
      var il = dm.GetILGenerator();
      il.Emit(OpCodes.Ldloca_S, il.DeclareLocal(TRect));
      il.Emit(OpCodes.Initobj, TRect);
      il.Emit(OpCodes.Ldloc_0);
      il.Emit(OpCodes.Ret);
      return dm;
    }
    private static void TryCreateDelegate<T>(DynamicMethod dm)
    {
      try
      {
        var co = dm.CreateDelegate(typeof(T));
        var value = co.DynamicInvoke();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        var indent = 0;
        while (ex.InnerException != null)
        {
          indent++;
          ex = ex.InnerException;
          Console.WriteLine(new string('\t', indent) + ex.Message);
        }
      }
    }
