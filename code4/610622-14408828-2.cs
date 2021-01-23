        public static uint GetFileSizeA(string filename)
        {
            WIN32_FIND_DATA findData;
            FindFirstFile(filename, out findData);
            return findData.nFileSizeLow;
        }
        public static uint GetFileSizeB(string filename)
        {
            IntPtr handle = CreateFile(
                filename,
                FileAccess.Read,
                FileShare.Read,
                IntPtr.Zero,
                FileMode.Open,
                FileAttributes.ReadOnly,
                IntPtr.Zero);
            long fileSize;
            GetFileSizeEx(handle, out fileSize);
            CloseHandle(handle);
            return (uint) fileSize;
        }
