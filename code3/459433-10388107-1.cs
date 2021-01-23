    [StructLayout(LayoutKind.Sequential, Size = 104)]
    internal struct Capability
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Driver;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string Device;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string BusInfo;
        public uint Version;
        public CapabilityFlags Capabilities;
    }
