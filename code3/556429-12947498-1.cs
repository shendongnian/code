    public static bool IsValidPath(string path)
    {
        try
        {
            string pt = Path.GetFullPath(path);
        }
        catch (Exception ex) // catch specific exception here
        {
            return false;
        }
        return true;
    }
