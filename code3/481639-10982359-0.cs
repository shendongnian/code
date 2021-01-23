    public static bool IsFileClosed(string filename)
    {
        try
        {
            using (var inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                return true;
            }
        }
        catch (IOException)
        {
            return false;
        }
    }
