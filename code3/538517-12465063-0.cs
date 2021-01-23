    public static class DirectoryInfoEx
    {
        public static long GetDirectorySize(this DirectoryInfo di)
        {
            long size = 0;
            
            var fileInfos = di.GetFiles();
            foreach (var fi in fileInfos)
            {
                size += fi.Length;
            }
            var subDirInfos = di.GetDirectories();
            foreach (var subDir in subDirInfos)
            {
                size += GetDirectorySize(subDir);
            }
            
            return size;
        }
    }
