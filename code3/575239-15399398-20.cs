    [StructLayout(LayoutKind.Sequential)]
    public struct MFTSystemRecords
    {
        public MFTRecord Mft;
        public MFTRecord MftMirror;
        public MFTRecord LogFile;
        public MFTRecord Volume;
        public MFTRecord AttributeDefs;
        public MFTRecord RootFile;
        public MFTRecord ClusterBitmap;
        public MFTRecord BootSector;
        public MFTRecord BadClusterFile;
        public MFTRecord SecurityFile;
        public MFTRecord UpcaseTable;
        public MFTRecord ExtensionFile;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public MFTRecord[] MftReserved;
        public MFTRecord MftFileExt;
    }
