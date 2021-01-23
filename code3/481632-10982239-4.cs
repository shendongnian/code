    private bool IsFileLocked(string file)
    {
        //check that problem is not in destination file
        if (File.Exists(file) == true)
        {
            FileStream stream = null;
            try
            {
                stream = File.Open(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (Exception ex2)
            {
                //_log.WriteLog(ex2, "Error in checking whether file is locked " + file);
                int errorCode = Marshal.GetHRForException(ex2) & ((1 << 16) - 1);
                if ((ex2 is IOException) && (errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION))
                {
                    return true;
                }
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        return false;
    }
