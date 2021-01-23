    private void IsFileOpen(FileInfo file)
    {
    	FileStream stream = null;
    	try {
    		stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
    	}
    	catch (Exception ex) {
    
    		if (ex is IOException && IsFileLocked(ex)) {
    			// do something here, either close the file if you have a handle or as a last resort terminate the process - which could cause corruption and lose data
    		}
    	}
    }
    
    private static bool IsFileLocked(Exception exception)
    {
    	int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
    	return errorCode == 32 || errorCode == 33;
    }
