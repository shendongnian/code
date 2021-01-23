    bool userExists(string pcName)
    {
        string[] files = Directory.GetFiles(usersFile);
        foreach (string fileName in files)
        {
            if (fileName == pcName)
            {
                return true;
            }
        }
        return false;
    }
