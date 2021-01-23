    private static IntPtr lib;
    ....
    
    public static void LoadNativeDll(string FileName)
    {
        if (lib != IntPtr.Zero)
        {
            return;
        }
        lib = NativeMethods.LoadLibrary(FileName);
        if (lib == IntPtr.Zero)
        {
            throw new Win32Exception();
        }
    }
