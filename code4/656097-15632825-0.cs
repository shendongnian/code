    [StructLayout(LayoutKind.Sequential)]
    public struct Result
    {
        public int Number;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string Name;
        public int Size;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct CoverObject
    {
        public int NumOfResults;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 4)]
        public Result[] Results;
    }
