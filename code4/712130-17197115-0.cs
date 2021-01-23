    public struct SDMSTATUS 
    {
        public byte error_cd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=9)]
        public byte sensor[];  
    }
