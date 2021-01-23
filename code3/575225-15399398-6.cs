    void Main()
    {    
        // To the metal, baby!
        using(var fileHandle = CreateFile(
            // Magic "give me the device" syntax
            @"\\.\c:", 
            // MUST explicitly provide both of these, not ReadWrite
            FileAccess.Read | FileAccess.Write, 
            // MUST explicitly provide both of these, not ReadWrite
            FileShare.Write | FileShare.Read, 
            IntPtr.Zero, 
            FileMode.Open, 
            FileAttributes.Normal,
            IntPtr.Zero))
        {
            if(fileHandle.IsInvalid)
            {
                // Doh!
                new Win32Exception().ToString().Dump();
            }
            else
            {
                // Boot sector ~ 512 bytes long
                byte[] buffer = new byte[512];
                NativeOverlapped overlapped = new NativeOverlapped();
                ReadFile(fileHandle, buffer, buffer.Length, IntPtr.Zero, ref overlapped);
                // Pin it so we can transmogrify it into a FAT structure
                var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {            
                    // note, I've got an NTFS drive, change yours to suit
                    var bootSector = (BootSector_NTFS)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(BootSector_NTFS));
                    Console.WriteLine(
                        "I think that the Master File Table is at absolute position:{0}, sector:{1}", 
                        bootSector.GetMftAbsoluteIndex(),
                        bootSector.GetMftAbsoluteIndex() / bootSector.BytesPerSector);
                    
                    // If you've got LinqPad, uncomment this to look at boot sector
                    bootSector.Dump();
                    
                    Console.WriteLine("Jumping to Master File Table...");
                    long lpNewFilePointer;
                    SetFilePointerEx(fileHandle, bootSector.GetMftAbsoluteIndex(), out lpNewFilePointer, SeekOrigin.Begin);
                    Console.WriteLine("Position now: {0}", lpNewFilePointer);
                    
                    // Read in one MFT entry
                    byte[] mft_buffer = new byte[bootSector.GetMftEntrySize()];
                    NativeOverlapped mft_overlapped = new NativeOverlapped();
                    Console.WriteLine("Reading $MFT entry...");
                    ReadFile(fileHandle, mft_buffer, mft_buffer.Length, IntPtr.Zero, ref mft_overlapped);
                    // Pin it for transmogrification
                    var mft_handle = GCHandle.Alloc(mft_buffer, GCHandleType.Pinned);
                    try
                    {
                        mft_buffer.Select((x,i) => x.ToString("X") + "(" + i.ToString("X") + ")").Dump();                    
                    }
                    finally
                    {
                        // make sure we clean up
                        mft_handle.Free();
                    }
                }
                finally
                {
                    // make sure we clean up
                    handle.Free();
                }
            }
        }
    }
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern SafeFileHandle CreateFile(
        string lpFileName,
        [MarshalAs(UnmanagedType.U4)] FileAccess dwDesiredAccess,
        [MarshalAs(UnmanagedType.U4)] FileShare dwShareMode,
        IntPtr lpSecurityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode dwCreationDisposition,
        [MarshalAs(UnmanagedType.U4)] FileAttributes dwFlagsAndAttributes,
        IntPtr hTemplateFile);
        
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern unsafe bool ReadFile(
        SafeFileHandle hFile,      // handle to file
        byte[] pBuffer,        // data buffer, should be fixed
        int NumberOfBytesToRead,  // number of bytes to read
        IntPtr pNumberOfBytesRead,  // number of bytes read, provide NULL here
        ref NativeOverlapped lpOverlapped // should be fixed, if not null
    );
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool SetFilePointerEx(
         SafeFileHandle hFile, 
         long liDistanceToMove,
         out long lpNewFilePointer, 
         SeekOrigin dwMoveMethod);
            
    [DllImport("kernel32.dll", SetLastError=true)]
    public static extern bool CloseHandle(IntPtr hHandle);
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
