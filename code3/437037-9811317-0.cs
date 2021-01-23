    private List<string> GetSubDirectories(string serverName, string folderPath)
    {
            List<string> subDirectories = new List<string>();
            string folder_path = Path.Combine(serverName, folderPath);            
            IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
            WIN32_FIND_DATA findData;
            IntPtr findHandle;
            findHandle = FindFirstFile(folder_path, out findData);
            if (findHandle == INVALID_HANDLE_VALUE)
            {
                int error = Marshal.GetLastWin32Error();
                Console.WriteLine(error.ToString());
                return null;
            }
            do
            {
                try
                {
                    if ((findData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) == FILE_ATTRIBUTE_DIRECTORY)
                        subDirectories.Add(findData.cFileName);                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            while (FindNextFile(findHandle, out findData));
            FindClose(findHandle);
            return subDirectories;
        }
        public const int FILE_ATTRIBUTE_DIRECTORY = 0x10;
        
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool FindClose(IntPtr hFindFile);
        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        };
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }
       
       
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);
        
    }
