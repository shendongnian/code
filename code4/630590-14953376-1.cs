    [DllImport("mydll.dll")]
    public static extern IntPtr getVersionText1(void);
    public string getVersionTextConst()
    {
        IntPtr ptr = getVersionText1();
        // assume returned string is utf-8 encoded
        return PtrToStringUtf8(ptr);
    }
    [DllImport("mydll.dll")]
    public static extern void getVersionText2(out IntPtr res);
    public string getVersionTextConst()
    {
        IntPtr ptr;
        getVersionText2(ptr);
        // assume returned string is utf-8 encoded
        String str = PtrToStringUtf8(ptr);
        // call native DLL function to free ptr
        // if no function exists, pinvoke C runtime's free()
        return str;
    }
    private static string PtrToStringUtf8(IntPtr ptr) // aPtr is nul-terminated
    {
        if (ptr == IntPtr.Zero)
            return "";
        int len = 0;
        while (System.Runtime.InteropServices.Marshal.ReadByte(ptr, len) != 0)
            len++;
        if (len == 0)
            return "";
        byte[] array = new byte[len];
        System.Runtime.InteropServices.Marshal.Copy(ptr, array, 0, len);
        return System.Text.Encoding.UTF8.GetString(array);
    }
