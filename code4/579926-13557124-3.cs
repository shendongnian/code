    DisposableObject d = new DisposableObject();
    Type t = typeof(DisposableObject);
    InterfaceMapping m = t.GetInterfaceMap(typeof(IDisposable));
    MethodInfo mi = d.GetType().GetMethod("Dispose");
    Console.WriteLine(mi == m.TargetMethods[0]); //true
