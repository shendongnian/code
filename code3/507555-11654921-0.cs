    private const string DllName =
        #if DEBUG
            "msvcr100d.dll";
        #else
            "msvcr100.dll"; 
        #endif
    public delegate void PureCallHandler();
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern PureCallHandler _set_purecall_handler(PureCallHandler handler);
