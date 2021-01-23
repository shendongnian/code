    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)] 
    public struct struktur
    {
        public uint ulSize;          // size of the NkflLibraryParam structure
        public uint ulVersion;       // version number of the interface specification
        public uint ulVMMMemorySize; // upper limit of the physical memory that can be used
        public IntPtr pNkflPtr;      // pointer to the StratoManager object
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] VMFileInfo;      // swap file information
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] DefProfPath; // <- this one is not included in the doc of NIKON (I still don't now what this should hold but it works if it's empty...)
    }
