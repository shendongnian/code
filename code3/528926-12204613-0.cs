    // Only call GetFileWithLongPath() if the path is too long
    // ... otherwise, new FileInfo() is sufficient
    private static FileInfo GetFile(string path)
    {
        if (path.Length >= MAX_FILE_PATH)
        {
            return GetFileWithLongPath(path);
        }
        else return new FileInfo(path);
    }
    static int MAX_FILE_PATH = 260;
    static int MAX_DIR_PATH = 248;
    private static FileInfo GetFileWithLongPath(string path)
    {
        string[] subpaths = path.Split('\\');
        StringBuilder sbNewPath = new StringBuilder(subpaths[0]);
        // Build longest sub-path that is less than MAX_PATH characters 
        for (int i = 1; i < subpaths.Length; i++)
        {
            if (sbNewPath.Length + subpaths[i].Length >= MAX_DIR_PATH)
            {
                subpaths = subpaths.Skip(i).ToArray();
                break;
            }
            sbNewPath.Append("\\" + subpaths[i]);
        }
        DirectoryInfo dir = new DirectoryInfo(sbNewPath.ToString());
        bool foundMatch = dir.Exists;
        if (foundMatch)
        {
            // Make sure that all of the subdirectories in our path exist. 
            // Skip the last entry in subpaths, since it is our filename. 
            // If we try to specify the path in dir.GetDirectories(),  
            // We get a max path length error. 
            int i = 0;
            while (i < subpaths.Length - 1 && foundMatch)
            {
                foundMatch = false;
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    if (subDir.Name == subpaths[i])
                    {
                        // Move on to the next subDirectory 
                        dir = subDir;
                        foundMatch = true;
                        break;
                    }
                }
                i++;
            }
            if (foundMatch)
            {
                // Now that we've gone through all of the subpaths, see if our file exists. 
                // Once again, If we try to specify the path in dir.GetFiles(),  
                // we get a max path length error. 
                foreach (FileInfo fi in dir.GetFiles())
                {
                    if (fi.Name == subpaths[subpaths.Length - 1])
                    {
                        return fi;
                    }
                }
            }
        }
        // If we didn't find a match, return null;
        return null;
    }
