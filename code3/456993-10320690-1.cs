    public struct Frame {
        public uint Identifier;
        
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=128)]
        public string Name;
    }
