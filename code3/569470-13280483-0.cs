    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TimesTree( uint frame );
    [DllImport("SimpleDLL.dll")]
    public static extern System.UInt32 DllFunctionPointer( uint i,
        [MarshalAs(UnmanagedType.FunctionPtr)] TimesTree callback ) ;
    static unsafe void Main(string[] args)
    {
        // ...
        System.UInt32 jRet = DllFunctionPointer(j, CallBack );
        // ...
    }
