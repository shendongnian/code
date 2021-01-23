    public static bool IsValidPath(string path)
    {
        try
        {
            string pt = Path.GetFullPath(path);
        }
        catch //(Exception NotSupportedException) // catch specific exception here or not if you want
        {
            return false;
        }
        return true;
    }
