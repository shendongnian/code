    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1),Serializable]
    public struct temp
    {
        [DataMember]
        public int req;
        [DataMember]
        public type m_type;
        [DataMember]
        public short id;
        [DataMember]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string x;
        [DataMember]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string y;
    }
