    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Header
    {
        public Byte version;
        public Byte type;
        public UInt16 length;
        public UInt32 id;
    }
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Struct
    {
        public Header header;
        public Byte field1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public Byte[] pad;
        public UInt32 field2;
    }
