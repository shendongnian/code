    public void  selectfolders(string filename)
    {
        FileInfo_Class fclass;
        DirInfo dirInfo = new DirectoryInfo(filename);
        FileInfo[] info = dirInfo.GetFiles("*.*");
        foreach (FileInfo f in info)
        {
            fclass = new FileInfo_Class();
            fclass.Name = f.Name;
            fclass.length = Convert.ToUInt32(f.Length);
            fclass.DirectoryName = f.DirectoryName;
            fclass.FullName = f.FullName;
            fclass.Extension = f.Extension;
            obcinfo.Add(fclass);
        }
        DirectoryInfo[] subDirectories = dirInfo.GetDirectories();
        foreach(DirectoryInfo directory in subDirectories)
        {
            selectfolders(directory.FullName);
        }
    }
