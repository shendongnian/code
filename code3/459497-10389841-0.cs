    private static void CopyAll(string SourcePath, string DestinationPath)
    {
    string[] directories = System.IO.Directory.GetDirectories(SourcePath, "*.*", SearchOption.AllDirectories);
    Parallel.ForEach(directories, dirPath =>
    {
        Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
    }); 
    string[] files = System.IO.Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories);
    Parallel.ForEach(files, newPath =>
    {
        File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
    }); 
    }
