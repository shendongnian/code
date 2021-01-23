    private static T Add<T>(T a, T b)
    {
      if (Program.<Add>o__SiteContainer0<T>.<>p__Site1 == null)
      {
        Program.<Add>o__SiteContainer0<T>.<>p__Site1 = CallSite<Func<CallSite, object, T>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(T), typeof(Program)));
      }
      Func<CallSite, object, T> arg_98_0 = Program.<Add>o__SiteContainer0<T>.<>p__Site1.Target;
      CallSite arg_98_1 = Program.<Add>o__SiteContainer0<T>.<>p__Site1;
      if (Program.<Add>o__SiteContainer0<T>.<>p__Site2 == null)
      {
        Program.<Add>o__SiteContainer0<T>.<>p__Site2 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Program), new CSharpArgumentInfo[]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), 
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
        }));
      }
      return arg_98_0(arg_98_1, Program.<Add>o__SiteContainer0<T>.<>p__Site2.Target(Program.<Add>o__SiteContainer0<T>.<>p__Site2, a, b));
    }
