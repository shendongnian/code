    [StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct ComPort {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=64)]
        public string com_port;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=256)]
        public string friendly_name;
        public TSS_Type sensor_type;
    }
