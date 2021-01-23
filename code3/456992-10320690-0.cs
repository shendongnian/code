    struct Frame
    {
        public uint Identifier;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 128)]
        public char[] Name;
    }
