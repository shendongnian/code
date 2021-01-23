    [DllImport("C:\\cppdll\\test1\\testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int subtractInts(int x, int y);
    [DllImport("C:\\cppdll\\test1\\testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int multiplyints(int x, int y);
    [DllImport("C:\\cppdll\\test1\\testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int addints(int x, int y);
    [DllImport("C:\\cppdll\\test1\\testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string returnteststring();
