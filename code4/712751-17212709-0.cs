    if (System.IO.Directory.Exists(sourcePath))
    {
        string[] files = System.IO.Directory.GetFiles(sourcePath);
        // Copy the files and overwrite destination files if they already exist. 
        foreach (string s in files)
        {
           // Use static Path methods to extract only the file name from the path.
           fileName = System.IO.Path.GetFileName(s);
           destFile = System.IO.Path.Combine(targetPath, fileName);
           System.IO.File.Copy(s, destFile, true);
        }
    }
    else
    {
        Console.WriteLine("Source path does not exist!");
    }
