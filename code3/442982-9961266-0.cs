    //work normal
    public static void F_Ldvirtftn_Action()
    {
      Action<ILGenerator> genfunc = il =>
      {
        il.Emit(OpCodes.Newobj, typeof(Program).GetConstructor(Type.EmptyTypes));
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldvirtftn, typeof(Program).GetMethod("Foo2"));
        il.Emit(OpCodes.Newobj, typeof(Action).GetConstructor(new[] { typeof(object), typeof(IntPtr) }));
        il.Emit(OpCodes.Ret);
      };
      Console.WriteLine(CreateDelegate<Func<object>>(genfunc).Invoke());
    }
    // failed: VerificationException: Operation could destabilize the runtime
    public static void F_IntPtr_Action()
    {
      Action<ILGenerator> genfunc = il =>
      {
        il.Emit(OpCodes.Newobj, typeof(Program).GetConstructor(Type.EmptyTypes));
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Call, typeof(Program).GetMethod("Ptr"));
        il.Emit(OpCodes.Newobj, typeof(Action).GetConstructor(new[] { typeof(object), typeof(IntPtr) }));
        il.Emit(OpCodes.Ret);
      };
      Console.WriteLine(CreateDelegate<Func<object>>(genfunc).Invoke());
    }
    // failed: VerificationException: Operation could destabilize the runtime 
    public static void F_Ldvirtftn_MyAction()
    {
      Action<ILGenerator> genfunc = il =>
      {
        il.Emit(OpCodes.Newobj, typeof(Program).GetConstructor(Type.EmptyTypes));
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldvirtftn, typeof(Program).GetMethod("Foo2"));
        il.Emit(OpCodes.Newobj, typeof(MyAction).GetConstructor(new[] { typeof(object), typeof(IntPtr) }));
        il.Emit(OpCodes.Ret);
      };
      Console.WriteLine(CreateDelegate<Func<object>>(genfunc).Invoke());
    }
    //work normal
    public static void F_IntPtr_MyAction()
    {
      Action<ILGenerator> genfunc = il =>
      {
        il.Emit(OpCodes.Newobj, typeof(Program).GetConstructor(Type.EmptyTypes));
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Call, typeof(Program).GetMethod("Ptr"));
        il.Emit(OpCodes.Newobj, typeof(MyAction).GetConstructor(new[] { typeof(object), typeof(IntPtr) }));
        il.Emit(OpCodes.Ret);
      };
      Console.WriteLine(CreateDelegate<Func<object>>(genfunc).Invoke());
    }
    public static IntPtr Ptr(object z)
    {
      return IntPtr.Zero;
    }
    public class MyAction
    {
      public MyAction(object z, IntPtr adr) { }
    }
