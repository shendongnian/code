    public void UpdateFiles(string directory, string otherDir)
    {
       var dirFiles = Directory.EnumerateFiles(directory, "*", 
                            SearchOption.AllDirectories);
       var otherDirFiles = Directory.EnumerateFiles(otherDir, "*", 
                            SearchOption.AllDirectories);
       foreach (var file in dirFiles)
       {
           string fi = Path.GetFileName(file);
           var newFile = otherDirFiles.Where(x => fi == Path.GetFileName(x));
           foreach(var foundFile in newFile)
              File.Copy(file , foundFile, true);
       }
    }
