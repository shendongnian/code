    // Get the current assembly. If the file is embedded inside a different
    // assembly you will need to get that assembly
    var assembly = Assembly.GetExecutingAssembly();
    using (var stream = assembly.GetManifestResourceStream("AssemblyName.test.txt"))
    using (var sr = new StreamReader(stream))
    {
        ...
    }
