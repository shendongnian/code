    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr LoadLibrary(string libname);
    private static void LoadNativeAssembly(string nativeBinaryPath, string assemblyName)
    {
        var path = Path.Combine(nativeBinaryPath, assemblyName);
    
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"{path} not found");
        }
    
        var ptr = LoadLibrary(path);
        if (ptr == IntPtr.Zero)
        {
            throw new Exception(string.Format(
                "Error loading {0} (ErrorCode: {1})",
                assemblyName,
                Marshal.GetLastWin32Error()));
        }          
    }
    public static void LoadNativeAssembliesv13(string rootApplicationPath)
    {
        var nativeBinaryPath = Environment.Is64BitProcess
        ? Path.Combine(rootApplicationPath, @"SqlServerTypes\x64\")
        : Path.Combine(rootApplicationPath, @"SqlServerTypes\x86\");
         
        LoadNativeAssembly(nativeBinaryPath, "msvcr120.dll");
        LoadNativeAssembly(nativeBinaryPath, "SqlServerSpatial130.dll");
    }
