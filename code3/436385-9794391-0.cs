    [StructLayout(LayoutKind.Sequential)]
    public struct fa_keydesc
    {
        public Int32 k_flags;                            
        public Int32 k_nparts;                                
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public fa_keypart[] kparts;
    };
