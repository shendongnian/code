    public static void UnZip(string zipFile, string folderPath)
    {
        if (!File.Exists(zipFile))
            throw new FileNotFoundException();
 
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
    
        Shell32.Shell objShell = new Shell32.Shell();
        Shell32.Folder destinationFolder = objShell.NameSpace(folderPath);
        Shell32.Folder sourceFile = objShell.NameSpace(zipFile);
 
        foreach (var file in sourceFile.Items())
        {
            destinationFolder.CopyHere(file, 4 | 16);
        }
    }
