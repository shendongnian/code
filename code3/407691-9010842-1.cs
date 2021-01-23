    while (IsFileLocked(new FileInfo("YourFilePath")))
    {
        // do something, for example wait a second
        Thread.Sleep(TimeSpan.FromSeconds(1));
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
