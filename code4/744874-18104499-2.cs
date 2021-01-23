    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += (sender, eventArgs) => Assembly.ReflectionOnlyLoad(eventArgs.Name);
    WindowsRuntimeMetadata.ReflectionOnlyNamespaceResolve += (sender, eventArgs) =>
    {
        string path =
            WindowsRuntimeMetadata.ResolveNamespace(eventArgs.NamespaceName, Enumerable.Empty<string>())
                .FirstOrDefault();
        if (path == null) return;
    
        eventArgs.ResolvedAssemblies.Add(Assembly.ReflectionOnlyLoadFrom(path));
    };
    
    Assembly loadFrom = Assembly.ReflectionOnlyLoadFrom(@"C:\....\WinRTApp.exe");
    Type[] types = loadFrom.GetExportedTypes();
    foreach (Type type in types)
    {
        Console.WriteLine(type);
    }
