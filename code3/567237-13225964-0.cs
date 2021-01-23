        string fileName = "test.txt";
        string sourcePath = @"C:\Users\Public\TestFolder";
        string targetPath =  @"C:\Users\Public\TestFolder\SubDir";
        // Use Path class to manipulate file and directory paths. 
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);
        // To copy a folder's contents to a new location: 
        // Create a new target folder, if necessary. 
        if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }
        System.IO.File.Copy(sourceFile, destFile, true);
