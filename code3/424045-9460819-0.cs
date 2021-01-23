    protected virtual bool IsFileLocked(FileInfo file)
    {
        FileStream stream = null;
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            // file is used by another process
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
        //file is not locked
        return false;
    }
