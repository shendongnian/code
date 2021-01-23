    2.1. `Process.GetCurrentProcess().Kill()`: Foo(-); Bar(-); Baz(-);
    2.2. `Environment.Exit(0)`: Foo(-); Bar(-); Baz(-);
    2.3. `Environment.FailFast("")`: Foo(-); Bar(-); Baz(-);
    2.4. `AppDomain.Unload(AppDomain.CurrentDomain)`: Foo(-); Bar(+); Baz(+);
    2.5. `Thread.CurrentThread.Abort()`: Foo(-); Bar(+); Baz(+);
