    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CON_SEND
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Command;
        public ushort Lc;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] DataIn;
        public ushort Le;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CON_RESP
    {
        public ushort LenOut;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] DataOut;
        public byte outA;
        public byte outB;
    }
