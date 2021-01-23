    public bool IsMsiExecFree(TimeSpan maxWaitTime)
    {
        _logger.Info(@"Waiting up to {0}s for Global\_MSIExecute mutex to become free...", maxWaitTime.TotalSeconds);
    
        // The _MSIExecute mutex is used by the MSI installer service to serialize installations
        // and prevent multiple MSI based installations happening at the same time.
        // For more info: http://msdn.microsoft.com/en-us/library/aa372909(VS.85).aspx
        
        const string installerServiceMutexName = "Global\\_MSIExecute";
        Mutex msiExecuteMutex = null;
        var isMsiExecFree = false;
        
        try
        {
            msiExecuteMutex = Mutex.OpenExisting(installerServiceMutexName,
                MutexRights.Synchronize);
            isMsiExecFree = msiExecuteMutex.WaitOne(maxWaitTime, false);
        }
        catch (WaitHandleCannotBeOpenedException)
        {
            // Mutex doesn't exist, do nothing
            isMsiExecFree = true;
        }
        catch (ObjectDisposedException)
        {
            // Mutex was disposed between opening it and attempting to wait on it, do nothing
            isMsiExecFree = true;
        }
        finally
        {
            if (msiExecuteMutex != null && isMsiExecFree)
                msiExecuteMutex.ReleaseMutex();
        }
    
        _logger.Info(@"Global\_MSIExecute mutex is free, or {0}s has elapsed.", maxWaitTime.TotalSeconds);
    
        return isMsiExecFree;
    }
