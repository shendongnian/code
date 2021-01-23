    bool status = false;
    bool bLockTaken = false; 
    // prepare here to prevent threadabort from occuring which could
    // destroy m_lock state.  lock(this) can't be used due to critical
    // finalizer and thinlock/syncblock escalation. 
    RuntimeHelpers.PrepareConstrainedRegions();
    try 
    { 
    }
    finally 
    {
        do
        {
            if (Interlocked.CompareExchange(ref m_lock, 1, 0) == 0) 
            {
                bLockTaken = true; 
                try 
                {
                    if (timerDeleted != 0) 
                        throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_Generic"));
                    status = ChangeTimerNative(dueTime,period);
                }
                finally 
                {
                    m_lock = 0; 
                } 
            }
            Thread.SpinWait(1);     // yield to processor 
        }
        while (!bLockTaken);
    }
    return status; 
