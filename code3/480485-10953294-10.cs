    public static FolderItem GetShellFolderItem(string path)
    {
        if (!FileProcessing.IsFile(path))
        {
            throw new ArgumentException("Path did not lead to a file", path);
        }
        int index = -1; 
        //get the index of the path item
        FileInfo info = new FileInfo(path);
        DirectoryInfo directoryInfo = info.Directory;
        for (int i = 0; i < directoryInfo.GetFileSystemInfos().Count(); i++)
        {
            if (directoryInfo.GetFileSystemInfos().ElementAt(i).Name == info.Name) //we've found the item in the folder
            {
                index = i;
                break;
            }
        }
        return GetShellFolder(path).Items().Item(index);
    }
