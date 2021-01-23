    unsafe static class Program
    {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Parameters
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public String Param1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public String Param2;
    }
    [DllImport(@"CTestDll2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void GetValue(StringBuilder sbOut, Parameters sbIn);
    static void Main(string[] args)
    {
        var p = new Parameters
        {
            Param1 = "abc",
            Param2 = "dfc"
        };
        var s = new StringBuilder("some text");
        GetValue(s, p);
    }
