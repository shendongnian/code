    public static bool IsValidPath(string path)
    {
        try
        {
            string pt = Path.GetFullPath(path);
        }
        catch (NotSupportedException ex)
        {
            return false;
        }
        return true;
    }
