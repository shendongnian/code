    AppDomain.CurrentDomain.AssemblyResolve += 
        (s, e) => OnAssemblyResolve(Environment.Is64BitProcess, e.Name);
    private Assembly LoadAssemblyIfExists(string path)
    {
        if (!File.Exists(path))
            return null;
        return Assembly.LoadFrom(path);
    }
    private Assembly OnAssemblyResolve(bool is64BitProcess, string assemblyDisplayName)
    {
        try
        {
            var assemblyName = new AssemblyName(assemblyDisplayName);
            if (assemblyName.Name == "Managed")
            {
                var assembly = Assembly.GetEntryAssembly() ?? 
                               Assembly.GetCallingAssembly();
                var path = Path.GetDirectoryName(assembly.Location);
                path = Path.Combine(path, is64BitProcess ? "x64" : "x86", "Managed.dll"); 
                return LoadAssemblyIfExists(path);
            }
        }
        catch (Exception e)
        {
            var message = string.Format(
                "Error resolving assembly {0}. Falling back to default resolve behavior", 
                assemblyDisplayName);
            Logger.WarnException(message, e);
        }
        return null;
    }
