    String path = Application.StartupPath;
    string[] pluginFiles = Directory.GetFiles(path, "*.dll");
    
    ipi = (
        // From each file in the files.
        from file in pluginFiles
        // Load the assembly.
        let asm = Assembly.LoadFile(file)
        // For every type in the assembly that is visible outside of
        // the assembly.
        from type in asm.GetExportedTypes()
        // Where the type implements the interface.
        where typeof(IPlugin).IsAssignableFrom(type)
        // Create the instance.
        select (IPlugin) Activator.CreateInstance(type)
    // Materialize to an array.
    ).ToArray();
