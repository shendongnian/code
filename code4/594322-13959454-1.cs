    /// <summary>
    /// Unmanaged sockaddr_in structure from Ws2def.h.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct sockaddr_in
    {
        /// <summary>
        /// short sa_family;
        /// </summary>
        public short sa_family;
    
        /// <summary>
        /// unsigned short sin_port;
        /// </summary>
        public ushort sin_port;
    
        /// <summary>
        /// struct in_addr addr;
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 4)]
        public byte[] addr;
    
        /// <summary>
        /// char sin_zero[8];
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 8)]
        public byte[] sin_zero;
    }
