    WindowsRuntimeMetadata.ReflectionOnlyNamespaceResolve += (sender, args) =>
    {
        var path = WindowsRuntimeMetadata.ResolveNamespace(args.NamespaceName, Enumerable.Empty<string>()).FirstOrDefault();
        if (path == null) return;
        args.ResolvedAssemblies.Add(Assembly.ReflectionOnlyLoadFrom(path));                
    };
