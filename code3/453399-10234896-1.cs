    public struct FILETIME
    {
         public UInt32 dwLowDateTime;
         public UInt32 dwHighDateTime;
    }
    public unsafe struct WIN32_FIND_DATAW
    {
        public UInt32 dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public UInt32 nFileSizeHigh;
        public UInt32 nFileSizeLow;
        public UInt32 dwReserved0;
        public UInt32 dwReserved1;
        public fixed Char cFileName[256];
        public fixed Char cAlternateFileName[14];
    }
