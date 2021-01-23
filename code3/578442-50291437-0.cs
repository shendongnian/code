    [DllImport("CppDll.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetString(string s);
            
    public string GetString_(string s)
    {            
        var ptr = GetString(s);                                
        var answerStr = Marshal.PtrToStringAnsi(ptr);
        return answerStr;
    }
