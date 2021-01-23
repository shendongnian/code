    public IEnumerable<FileInfo> GetFilesRecursiveEnumerable(DirectoryInfo dir)
    {
        ...
        foreach (FileSystemInfo x in files)
        {
            DirectoryInfo dirInfo = x as DirectoryInfo;
            if (dirInfo != null)
            {
                foreach (FileInfo f in GetFilesRecursiveEnumerable(dirInfo))
                {
                    FileReady(f);
                }
            }
            ...
        }
    }
