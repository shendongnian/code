    public delegate void GetNameDelegate(IntPtr name, out ushort length); 
    ....
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void delegateGetName(IntPtr name, out ushort length);
    ....
    static void GetName(IntPtr name, out ushort length)
    {
        byte[] buffer = Encoding.Default.GetBytes("one two three");
        length = (ushort)buffer.Length;
        Marshal.Copy(buffer, 0, name, buffer.Length);
    }   
