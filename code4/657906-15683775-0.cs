    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CON_SEND
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string Command;
        public ushort Lc;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string DataIn;
        public ushort Le;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CON_RESP
    {
        public ushort LenOut;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string DataOut;
        public byte outA;
        public byte outB;
    }
