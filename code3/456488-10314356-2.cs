    [DllImport("Testing1.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int ReadTest(string filename, StringBuilder buffer, int len);
    ....
    StringBuilder buffer = new StringBuilder(100);
    int retval = ReadTest(FullySpecifiedFileName, buffer, buffer.Capacity);
