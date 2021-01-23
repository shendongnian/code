    private static bool CanCopyAllFiles(string source, string dest)
    {
        System.IO.FileInfo[] filesSource = new System.IO.DirectoryInfo(source).GetFiles();
        System.IO.FileInfo[] filesTarget = new System.IO.DirectoryInfo(dest).GetFiles();
        foreach (FileInfo fileInfo in filesSource)
        {
            FileInfo tmp = filesTarget.FirstOrDefault(f => f.Name == fileInfo.Name);
            if (tmp != null && tmp.LastWriteTime > fileInfo.LastWriteTime)
            {
                return false;
            }
        }
        return true;
    }
