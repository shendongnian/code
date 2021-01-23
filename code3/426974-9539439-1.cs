    static bool DeleteDirectoriesRecursive(DirectoryInfo d)
    {
        bool remove = true;
    
        foreach (DirectoryInfo c in d.GetDirectories())
        {
            remove &= DeleteDirectoriesRecursive(c);
        }
    
        if (remove && d.GetFiles().Length == 0) {
            d.Delete();
            return true;
        }
    
        return false;
    }
