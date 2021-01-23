    [DllImport("Kernel32.dll")]
    private static extern IntPtr LoadLibrary(string path);
    void LoadLibraryIfExists(string path)
    {
        if (File.Exists(path))
            LoadLibrary(path);
    }
    var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
    var path = Path.GetDirectoryName(assembly.Location);
    path = Path.Combine(path, Environment.Is64BitProcess ? "x64" : "x86", "unmanaged.dll");
    LoadLibraryIfExists(path);
