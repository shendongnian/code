    private void button1_Click(object sender, EventArgs e)
    {
        CopyContentsToSubFolderWithSameName(@"C:\Temp");
    }
    private void CopyContentsToSubFolderWithSameName(string path)
    {
        DirectoryInfo currDir = new DirectoryInfo(path);
        DirectoryInfo subDir = 
            Directory.CreateDirectory(currDir.FullName + "\\" + currDir.Name);
        IEnumerable<DirectoryInfo> parentFolders = 
            subDir.Parent.EnumerateDirectories();
        // Copy files in the current directory to the destination directory
        foreach (FileInfo file in currDir.GetFiles())
        {
            file.MoveTo(subDir.FullName + "\\" + file.Name);
        }
        // Copy directories (including files) in the current directory 
        // to the destination directory
        foreach (DirectoryInfo dir in parentFolders)
        {
            if (dir.Name != subDir.Name)
            {
                dir.MoveTo(subDir.FullName + "\\" + dir.Name);
            }
        }
    }
