    catch (Exception ex) {
    if (ex is IOException && IsFileLocked(ex)) {
    //Confirm the code see's it as a FileLocked issue, not some other exception
    //its not safe to unlock files used by other processes, because the other process is likely reading/writing it. 
    }
    }
    
    private static bool IsFileLocked(Exception exception)
    {
    	int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
    	return errorCode == 32 || errorCode == 33;
    }
