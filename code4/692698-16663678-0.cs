    public static string CreateFile(string path, string title)
    {
        string npath = path + title + ".txt";
        if (!File.Exists(npath))
            File.CreateText(npath); //<-- File is not closed !!!
        return npath;
    }
