    public delegate void MyCallback();
    [DllImport("MYDLL.DLL", CallingConvention = CallingConvention.Cdecl))] 
    public static extern void MyUnmanagedApi(MyCallback callback);
    
    as above ...
