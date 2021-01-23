    [DllImport("TestDll.dll"), CallingConvention = CallingConvention.Cdecl]
    private static extern IntPtr ToUpper(string s);
    public static string ToUpper_2(string s) 
    {
        return Marshal.PtrToStringAnsi(ToUpper(string s));
    }
