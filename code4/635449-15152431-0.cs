    public FileAttributes GetFileAttributes()
    {
        ...
        if(/*this file is read-only*/)
        {
             return fileSystemInfo.Attributes | FileAttributes.ReadOnly;
        }
        ...
    }
