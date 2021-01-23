    [StructLayout(LayoutKind.Sequential), Serializable]
    public struct AESContext
    {
        /// int nr; 
        public int nr;
    
        /// unsigned long *rk;
        public UIntPtr rk;
    
        // unsigned long buf[68];
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 68)]
        public uint[] buf;
    }
