    Dictionary<string, ReaderWriterLockSlim> lockDict = new Dictionary<string, ReaderWriterLockSlim>();
    ReaderWriterLockSlim LockFile(string filename, bool readOnly)
    {
        var fullPath = System.IO.Path.GetFullPath(filename);
        ReaderWriterLockSlim myLock;
        // lock the dictionary while we're accessing it
        lock (lockDict)
        {
            if (!lockDict.TryGetValue(fullPath, out myLock))
            {
                myLock = new ReaderWriterLockSlim();
                lockDict[fullPath] = myLock;
            }
        }
        // only block on the file lock once the dictionary is unlocked
        if (readOnly)
            myLock.EnterReadLock();
        else
            myLock.EnterWriteLock();
        // file is now "locked", so caller can proceed with read/write, then unlock
        return myLock;
    }
