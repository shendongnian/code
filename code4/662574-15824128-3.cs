    AppDomain.CurrentDomain.AssemblyResolve +=
    (sender, args) =>
    {
        // System.Diagnostics.Debugger.Break();
        // Lookup what's your namespace in project properties
        String resourceName = "YourAssemblyNamespace." +
            new AssemblyName(args.Name).Name + ".dll";
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
    ==>
            if (stream == null)
                return null;
    ==>
            Byte[] assemblyData = new Byte[stream.Length];
            stream.Read(assemblyData, 0, assemblyData.Length);
            return Assembly.Load(assemblyData);
        }
    };
