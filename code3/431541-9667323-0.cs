    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MsgStruct
    {
        public uint result;
        public uint command;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2001)]
        public byte[] information;
        public ushort informationLength;
    }
