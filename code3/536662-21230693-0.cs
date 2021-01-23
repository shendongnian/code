    public static void DeleteFilesAndFoldersRecursively(string target_dir)
    {
        foreach (string file in Directory.GetFiles(target_dir))
        {
            File.Delete(file);
        }
    
        foreach (string subDir in Directory.GetDirectories(target_dir))
        {
            DeleteFilesAndFoldersRecursively(subDir);
        }
    
        Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
        Directory.Delete(target_dir);
    }
