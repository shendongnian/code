    // block until we're not using the file anymore
    var myLock = LockFile(filename, readOnly: false);
    try
    {
        using (var file = new StreamWriter(filename))
        {
        ...
        }
    }
    finally
    {
        myLock.ExitWriteLock();
    }
