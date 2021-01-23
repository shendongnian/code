    [DllImport("yourfile.dll", CharSet = CharSet.Ansi)]
    public static extern sbyte service_GetParameter ( String parameter, Int32 length, ref IntPtr val);
    public static string ServiceGetParameter(string parameter, int maxLength)
    {
        string ret = null;
        IntPtr buf = Marshal.AllocCoTaskMem(maxLength+1);
        try
        {
            Marshal.WriteByte(buf, maxLength, 0); //Ensure there will be a null byte after call
            IntPtr buf2 = buf;
            service_GetParameter(parameter, maxLength, ref buf2);
            System.Diagnostics.Debug.Assert(buf == buf2, "The C++ function modified the pointer, it wasn't supposed to do that!");
            ret = Marshal.PtrToStringAnsi(buf);
        }
        finally { Marshal.FreeCoTaskMem(buf); }
        return ret;
    }
