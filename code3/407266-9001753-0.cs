    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += MyResolve;
    AppDomain.CurrentDomain.AssemblyResolve += MyResolve;
    private Assembly MyResolve(Object sender, ResolveEventArgs e) {
        Console.Error.WriteLine("Resolving assembly {0}", e.Name);
        // Load the assembly from your private path, and return the result
    }
