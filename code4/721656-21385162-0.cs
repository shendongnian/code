    public static bool DirectoryVisible(string path)
    {
        try
        {
            Directory.GetAccessControl(path);
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            return true;
        }
        catch
        {
            return false;
        }
    }
