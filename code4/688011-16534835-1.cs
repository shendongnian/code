    foreach (var v in typeof(/*any type*/)
                          .Assembly.GetTypes()
                          .Where(a => a.IsClass 
                                  && typeof(IDisposable).IsAssignableFrom(a)
                                  && a.GetInterfaces().Where(
                                   i=>i!=typeof(IDisposable)
                           ).All(i=>!typeof(IDisposable).IsAssignableFrom(i))))
    {
       foreach (var s in v.GetInterfaces())
           Console.WriteLine(v.FullName + ":" + s.Name);
    }
