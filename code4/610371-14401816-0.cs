    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)] 
    public struct DEVMGR_DEVICE_INFORMATION 
    { 
        public UInt32 dwSize; 
        public IntPtr hDevice; 
        public IntPtr hParentDevice; 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)] 
        public String szLegacyName; 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] 
        public String szDeviceKey; 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] 
        public String szDeviceName; 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] 
        public String szBusName; 
    } 
