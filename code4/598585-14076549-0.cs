    public sealed class DirectorySize
    {
        public static long GetDirectorySize(DirectoryInfo dir)
        {
            long total = 0;
            FileAttributes attributes = File.GetAttributes(dir.FullName);
            if (!((attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint))
            {
                FileInfo[] fileInfos = dir.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    total += fileInfo.Length;
                }
                DirectoryInfo[] dirInfos = dir.GetDirectories();
                foreach (DirectoryInfo dirInfo in dirInfos)
                {
                    total += DirectorySize.GetDirectorySize(dirInfo);
                }
            }
            return total;
        }
    }
