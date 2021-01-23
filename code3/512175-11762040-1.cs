    try
    {
        if(!IsFileLocked(f))
        {
            f.Delete();
            fTemp.MoveTo(f.FullName);
            Console.WriteLine("INFO: Old file deleted new file moved in > {0}", f.FullName);
        }
    }
	protected virtual bool IsFileLocked(FileInfo file)
	{
	    FileStream stream = null;
	    try
	    {
		stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
	    }
	    catch (IOException)
	    {
		//the file is unavailable because it is:
		//still being written to
		//or being processed by another thread
		//or does not exist (has already been processed)
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
