    public enum MftRecordFlags : ushort
    {
        MFT_RECORD_IN_USE = 0x0001,
        MFT_RECORD_IS_DIRECTORY = 0x0002,
        MFT_RECORD_IN_EXTEND = 0x0004,
        MFT_RECORD_IS_VIEW_INDEX = 0x0008,
        MFT_REC_SPACE_FILLER = 0xffff
    }
    public enum MftAttributeType : uint
    {
        AT_UNUSED = 0,
        AT_STANDARD_INFORMATION = 0x10,
        AT_ATTRIBUTE_LIST = 0x20,
        AT_FILENAME = 0x30,
        AT_OBJECT_ID = 0x40,
        AT_SECURITY_DESCRIPTOR = 0x50,
        AT_VOLUME_NAME = 0x60,
        AT_VOLUME_INFORMATION = 0x70,
        AT_DATA = 0x80,
        AT_INDEX_ROOT = 0x90,
        AT_INDEX_ALLOCATION = 0xa0,
        AT_BITMAP = 0xb0,
        AT_REPARSE_POINT = 0xc0,
        AT_EA_INFORMATION = 0xd0,
        AT_EA = 0xe0,
        AT_PROPERTY_SET = 0xf0,
        AT_LOGGED_UTILITY_STREAM = 0x100,
        AT_FIRST_USER_DEFINED_ATTRIBUTE = 0x1000,
        AT_END = 0xffffffff
    }
    public enum MftAttributeDefFlags : byte
    {
        ATTR_DEF_INDEXABLE = 0x02, /* Attribute can be indexed. */
        ATTR_DEF_MULTIPLE = 0x04, /* Attribute type can be present multiple times in the mft records of an inode. */
        ATTR_DEF_NOT_ZERO = 0x08, /* Attribute value must contain at least one non-zero byte. */
        ATTR_DEF_INDEXED_UNIQUE = 0x10, /* Attribute must be indexed and the attribute value must be unique for the attribute type in all of the mft records of an inode. */
        ATTR_DEF_NAMED_UNIQUE = 0x20, /* Attribute must be named and the name must be unique for the attribute type in all of the mft records of an inode. */
        ATTR_DEF_RESIDENT = 0x40, /* Attribute must be resident. */
        ATTR_DEF_ALWAYS_LOG = 0x80, /* Always log modifications to this attribute, regardless of whether it is resident or
                    non-resident.  Without this, only log modifications if the attribute is resident. */
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct MftInternalAttribute
    {
        [FieldOffset(0)]
        public MftAttributeType AttributeType;
        [FieldOffset(4)]
        public int Length;
        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.Bool)]
        public bool NonResident;
        [FieldOffset(9)]
        public byte NameLength;
        [FieldOffset(10)]
        public short NameOffset;
        [FieldOffset(12)]
        public int AttributeFlags;
        [FieldOffset(14)]
        public short Instance;
        [FieldOffset(16)]
        public ResidentAttribute ResidentAttribute;
        [FieldOffset(16)]
        public NonResidentAttribute NonResidentAttribute;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ResidentAttribute
    {
        public int ValueLength;
        public short ValueOffset;
        public byte ResidentAttributeFlags;
        public byte Reserved;
        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}:{3}", ValueLength, ValueOffset, ResidentAttributeFlags, Reserved);
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NonResidentAttribute
    {
        public long LowestVcn;
        public long HighestVcn;
        public short MappingPairsOffset;
        public byte CompressionUnit;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Reserved;
        public long AllocatedSize;
        public long DataSize;
        public long InitializedSize;
        public long CompressedSize;
        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}", LowestVcn, HighestVcn, MappingPairsOffset, CompressionUnit, AllocatedSize, DataSize, InitializedSize, CompressedSize);
        }
    }
    public struct MftAttribute
    {
        public MftInternalAttribute Attribute;
        [field: NonSerialized]
        public string Name;
        [field: NonSerialized]
        public byte[] Data;
        [field: NonSerialized]
        public object Payload;
        public static MftAttribute FromBytes(byte[] buffer)
        {
            var hnd = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var attr = (MftInternalAttribute)Marshal.PtrToStructure(hnd.AddrOfPinnedObject(), typeof(MftInternalAttribute));
                var ret = new MftAttribute() { Attribute = attr };
                ret.Data = buffer.Skip(Marshal.SizeOf(attr)).Take(attr.Length).ToArray();
                if (ret.Attribute.AttributeType == MftAttributeType.AT_STANDARD_INFORMATION)
                {
                    var payloadHnd = GCHandle.Alloc(ret.Data, GCHandleType.Pinned);
                    try
                    {
                        var payload = (MftStandardInformation)Marshal.PtrToStructure(payloadHnd.AddrOfPinnedObject(), typeof(MftStandardInformation));
                        ret.Payload = payload;
                    }
                    finally
                    {
                        payloadHnd.Free();
                    }
                }
                return ret;
            }
            finally
            {
                hnd.Free();
            }
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MftStandardInformation
    {
        public ulong CreationTime;
        public ulong LastDataChangeTime;
        public ulong LastMftChangeTime;
        public ulong LastAccessTime;
        public int FileAttributes;
        public int MaximumVersions;
        public int VersionNumber;
        public int ClassId;
        public int OwnerId;
        public int SecurityId;
        public long QuotaChanged;
        public long Usn;
    }
    // Note: dont have fat32, so can't verify all these...they *should* work, tho
    // refs:
    //    http://www.pjrc.com/tech/8051/ide/fat32.html
    //    http://msdn.microsoft.com/en-US/windows/hardware/gg463084
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto, Pack = 0, Size = 90)]
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] BPB_Reserved;
        public byte BS_DrvNum;
        public byte BS_Reserved1;
        public byte BS_BootSig;
        public int BS_VolID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BS_VolLab;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string BS_FilSysType;
    }
