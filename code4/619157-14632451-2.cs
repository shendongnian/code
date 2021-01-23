    [StructLayout(LayoutKind.Explicit, Size = 17, CharSet = CharSet.Ansi), Serializable]
    internal struct Header
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        [FieldOffset(0)]
        public string header;
        
        [FieldOffset(5)]
        public int version;
        [FieldOffset(9)]
        public int diroffset;
        [FieldOffset(13)]
        public int direntries;
    }
