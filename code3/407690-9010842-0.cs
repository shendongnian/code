    while (IsFileLocked(new FileInfo("YourFilePath")))
    {
        // do something
    }
    // file is not locked
    public static bool IsFileLocked(FileInfo file)
    {
        FileStream stream = null;
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
        return false;
    }
