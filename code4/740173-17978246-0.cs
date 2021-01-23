    public void UpdateFiles(string directory, string otherDir)
    {
       var dirFiles = Directory.EnumerateFiles(directory, "*.*", 
                            SearchOption.AllDirectories);
       var otherDirFiles = Directory.EnumerateFiles(otherDir, "*.*", 
                            SearchOption.AllDirectories);
       foreach (var file in dirFiles)
       {
           FileInfo fi = new FileInfo(file);
           var newFile = otherDirFiles.Where(x => fi.Name == new FileInfo(x).Name);
           foreach(var foundFile in newFile)
              File.Copy(fi.FullName, foundFile, true);
       }
    }
