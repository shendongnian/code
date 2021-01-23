    public const int MAX_PATH = 260;
    public const int MAX_ALTERNATE = 14;
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
        public static implicit operator long(FILETIME ft)
        {
            return (((long)ft.dwHighDateTime) << 32) | ft.dwLowDateTime;
        }
    };
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    public struct WIN32_FIND_DATA
    {
        public FileAttributes dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAX_PATH)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAX_ALTERNATE)]
        public string cAlternate;
    }
    
    [DllImport("kernel32", CharSet=CharSet.Unicode)]
    public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);
    
    [DllImport("kernel32", CharSet=CharSet.Unicode)]
    public static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);
    
    [DllImport("kernel32.dll")]
    public static extern bool FindClose(IntPtr hFindFile);
    private static IEnumerable<string> FilesWithinDates(string directory, DateTime minCreated, DateTime maxCreated)
    {
        long startFrom = minCreated.ToFileTimeUtc();
        long endAt = maxCreated.ToFileTimeUtc();
        WIN32_FIND_DATA findData;
        IntPtr findHandle = FindFirstFile(@"\\?\" + directory + @"\*", out findData);
        if(findHandle != new IntPtr(-1))
        {
            do
            {
                if(
                    (findData.dwFileAttributes & FileAttributes.Directory) == 0
                    &&
                    findData.ftCreationTime >= startFrom
                    &&
                    findData.ftCreationTime <= endAt
                )
                {
                    yield return findData.cFileName;
                }
            }
            while(FindNextFile(findHandle, out findData));
            FindClose(findHandle);
        }
    }
