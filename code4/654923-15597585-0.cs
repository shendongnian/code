    [StructLayout(LayoutKind.Sequential)]
    struct SwitchTime
    {
        public byte st1 { get; set; }
        public byte st2 { get; set; }
    }
    
    [StructLayout(LayoutKind.Sequential,Size=3)]
    struct SwitchParam
    {
        public byte sp1 { get; set; }
        public byte sp2 { get; set; }
        public byte sp3 { get; set; }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    struct SwitchRecord
    {
        public SwitchTime switchTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public SwitchParam[] switchParams;
    }
