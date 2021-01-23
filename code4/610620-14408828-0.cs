        public static uint GetFileSizeA(string filename)
        {
            WIN32_FIND_DATA findData;
            FindFirstFile(filename, out findData);
            return findData.nFileSizeLow;
        }
        public static uint GetFileSizeB(string filename)
        {
            SafeFileHandle handle = CreateFile(
                filename,
                FileAccess.Read,
                FileShare.Read,
                IntPtr.Zero,
                FileMode.Open,
                FileAttributes.ReadOnly,
                IntPtr.Zero);
            long fileSize;
            GetFileSizeEx(handle, out fileSize);
            return (uint) fileSize;
        }
