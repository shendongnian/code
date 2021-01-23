    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string dllToLoad);
    [DllImport("kernel32.dll")]
    public static extern bool FreeLibrary(IntPtr hModule);
    
    IntPtr pDll = LoadLibrary("library.dll");
    
    FreeLibrary(pDll);
    
    
