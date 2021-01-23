    [StructLayout(LayoutKind.Sequential)]
    struct TestStruct
    {
        public byte Mode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Data;
    }
