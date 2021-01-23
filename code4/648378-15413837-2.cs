    [DllImport("testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int subtractInts(int x, int y);
    [DllImport("testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int multiplyInts(int x, int y);
    [DllImport("testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int addInts(int x, int y);
    [DllImport("testDLL1_medium.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string returnTestString();
