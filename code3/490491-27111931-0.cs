        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern uint GetFileAttributes(string lpFileName);
        public static bool DirectoryExists(string path)
        {
            uint attributes = GetFileAttributes(path.StartsWith(@"\\?\") ? path : @"\\?\" + path);
            if (attributes != 0xFFFFFFFF)
            {
                return ((FileAttributes)attributes).HasFlag(FileAttributes.Directory);
            }
            else
            {
                return false;
            }
        }
        public static bool FileExists(string path)
        {
            uint attributes = GetFileAttributes(path.StartsWith(@"\\?\") ? path : @"\\?\" + path);
            if (attributes != 0xFFFFFFFF)
            {
                return !((FileAttributes)attributes).HasFlag(FileAttributes.Directory);
            }
            else
            {
                return false;
            }
        }
