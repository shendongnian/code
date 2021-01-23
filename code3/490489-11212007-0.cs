    const int MAX_PATH = 260;
    
    private static void checkPath(string path)
    {
        if (path.Length >= MAX_PATH)
        {
            checkFile_LongPath(path);
        }
        else if (!File.Exists(path))
        {
            Console.WriteLine("   *  File: " + path + " does not exist.");
        }
    }
