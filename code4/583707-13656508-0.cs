    Thread jitter = new Thread(() =>
    {
      foreach (var type in Assembly.Load("MyHavyAssembly, Version=1.8.2008.8," + 
               " Culture=neutral, PublicKeyToken=8744b20f8da049e3").GetTypes())
      {
        foreach (var method in type.GetMethods(BindingFlags.DeclaredOnly | 
                            BindingFlags.NonPublic | 
                            BindingFlags.Public | BindingFlags.Instance | 
                            BindingFlags.Static))
        {
          System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod(method.MethodHandle);
        }
      }
    });
    jitter.Priority = ThreadPriority.Lowest;
    jitter.Start();
