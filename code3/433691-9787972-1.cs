    SendOrPostCallback callback = o => Console.WriteLine((string) o));
    SynchronizationContext context = SynchronizationContext.Current;
    Task t = Task.Factory.StartNew(
               () =>
               {
                   RunShellScripts(); // maybe also parallelize this method
                   // or XML-RPC
                   context.Post(callback, "Work finished!");
               });
