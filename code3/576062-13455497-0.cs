    public MainPage()
    {
       var handler = Create<MouseEventHandler>();
       this.LayoutRoot.MouseMove += handler;
    }
    public static void MyEventHandler(object sender, object args)
    {
        Debug.WriteLine("MyEventHandler({0}, {1})", sender, args);
    }
    private TDelegate Create<TDelegate>()
    {
        // retrieve parameter types from delegate type
        var delegateType = typeof(TDelegate);
        var invoke = delegateType.GetMethod("Invoke");
        var parameterTypes = (from p in invoke.GetParameters()
                              select p.ParameterType).ToArray();
        // create dynamic event handler having TDelegate signature
        var method = new DynamicMethod("", null, parameterTypes);
        var myEventHandlerMethod = typeof(MainPage).GetMethod("MyEventHandler");
        var generator = method.GetILGenerator();
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldarg_1);
        generator.Emit(OpCodes.Call, myEventHandlerMethod);    // invoke my event handler
        generator.Emit(OpCodes.Ret);
        return (TDelegate)(object)method.CreateDelegate(delegateType);
    }
