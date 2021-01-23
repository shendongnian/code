    int retryCount = 0;
    while (retryCount < MaxRetryCount && isf.FileExists(fileName))
    {
        try
        {
            isf.DeleteFile(fileName);
        }
        catch (IsolatedStorageException)
        {
            ++retryCount;
            // maybe notify user and delay briefly
            // or forget about the retry and log an error. Let user try it again.
        }
    }
