    [DllImport(_dllLocation, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr getname(string track1, int len);
    string track = "hello12345"; 
    IntPtr namePtr = UnsafeNativeMethods.getname(track, 160);
    Byte[] name = new Byte[/* some size here - it is not clear how*/];
    Marshal.Copy(namePtr, name, 0, name.Length);
