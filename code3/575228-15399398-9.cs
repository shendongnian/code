    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi, Pack=0)]
    public struct JumpBoot
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.U1, SizeConst=3)]
        public byte[] BS_jmpBoot;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
        public string BS_OEMName;
    }
    [StructLayout(LayoutKind.Explicit, CharSet=CharSet.Ansi, Pack=0, Size=90)]
    public struct BootSector_NTFS
    {
        [FieldOffset(0)]
        public JumpBoot JumpBoot;    
        [FieldOffset(0xb)]
        public short BytesPerSector;
        [FieldOffset(0xd)]
        public byte SectorsPerCluster;
        [FieldOffset(0xe)]
        public short ReservedSectorCount;
        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
        public byte[] Reserved0_MUSTBEZEROs;
        [FieldOffset(0x15)]
        public byte BPB_Media;
        [FieldOffset(0x16)]
        public short Reserved1_MUSTBEZERO;
        [FieldOffset(0x18)]
        public short SectorsPerTrack;
        [FieldOffset(0x1A)]
        public short HeadCount;
        [FieldOffset(0x1c)]
        public int HiddenSectorCount;
        [FieldOffset(0x20)]
        public int Reserved5;
        [FieldOffset(0x24)]
        public int Reserved6;
        [FieldOffset(0x28)]
        public long TotalSectors;
        [FieldOffset(0x30)]
        public long MftClusterNumber;
        [FieldOffset(0x38)]
        public long MftMirrorClusterNumber;
        [FieldOffset(0x40)]
        public byte ClustersPerMftRecord;
        [FieldOffset(0x41)]
        public byte Reserved7;
        [FieldOffset(0x42)]
        public short Reserved8;
        [FieldOffset(0x44)]
        public byte ClustersPerIndexBuffer;
        [FieldOffset(0x45)]
        public byte Reserved9;
        [FieldOffset(0x46)]
        public short ReservedA;    
        [FieldOffset(0x48)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)] 
        public byte[] SerialNumber;
        [FieldOffset(0x50)]
        public int Checksum;
        
        public long GetMftAbsoluteIndex()
        {
            return (BytesPerSector * SectorsPerCluster * MftClusterNumber);
        }
        public long GetMftEntrySize()
        {
            return (BytesPerSector * SectorsPerCluster * ClustersPerMftRecord);
        }
    }
    // Note: dont have fat32, so can't verify all these...they *should* work, tho
    // refs:
    //    http://www.pjrc.com/tech/8051/ide/fat32.html
    //    http://msdn.microsoft.com/en-US/windows/hardware/gg463084
    [StructLayout(LayoutKind.Explicit, CharSet=CharSet.Auto, Pack=0, Size=90)]
    public struct BootSector_FAT32
    {
        [FieldOffset(0)]
        public JumpBoot JumpBoot;    
        [FieldOffset(11)]
        public short BPB_BytsPerSec;
        [FieldOffset(13)]
        public byte BPB_SecPerClus;
        [FieldOffset(14)]
        public short BPB_RsvdSecCnt;
        [FieldOffset(16)]
        public byte BPB_NumFATs;
        [FieldOffset(17)]
        public short BPB_RootEntCnt;
        [FieldOffset(19)]
        public short BPB_TotSec16;
        [FieldOffset(21)]
        public byte BPB_Media;
        [FieldOffset(22)]
        public short BPB_FATSz16;
        [FieldOffset(24)]
        public short BPB_SecPerTrk;
        [FieldOffset(26)]
        public short BPB_NumHeads;
        [FieldOffset(28)]
        public int BPB_HiddSec;
        [FieldOffset(32)]
        public int BPB_TotSec32;
        [FieldOffset(36)]
        public FAT32 FAT;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct FAT32
    {
        public int BPB_FATSz32;
        public short BPB_ExtFlags;
        public short BPB_FSVer;
        public int BPB_RootClus;
        public short BPB_FSInfo;
        public short BPB_BkBootSec;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
        public byte[] BPB_Reserved;
        public byte BS_DrvNum;
        public byte BS_Reserved1;
        public byte BS_BootSig;
        public int BS_VolID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=11)] 
        public string BS_VolLab;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)] 
        public string BS_FilSysType;
    }
