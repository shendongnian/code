    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct TOUCHINPUT {
        /// LONG->int
        public int x;
        /// LONG->int
        public int y;
        /// HANDLE->void*
        public System.IntPtr hSource;
        /// DWORD->unsigned int
        public uint dwID;
        /// DWORD->unsigned int
        public uint dwFlags;
        /// DWORD->unsigned int
        public uint dwMask;
        /// DWORD->unsigned int
        public uint dwTime;
        /// ULONG_PTR->unsigned int
        public uint dwExtraInfo;
        /// DWORD->unsigned int
        public uint cxContact;
        /// DWORD->unsigned int
        public uint cyContact;
    }
