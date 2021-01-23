    static public void ReproTest()
    {
        var rwlock = new ReaderWriterLockSlim();
        rwlock.EnterWriteLock();
        s_logger.Info("0:Enter");
        bool taken1 = false;
        var reader = new Thread(() =>
        {
            try
            {
                rwlock.EnterReadLock();
                s_logger.Info("1:Enter");
                // only set to true if taken
                taken1 = true;
            }
            catch (ThreadInterruptedException)
            {
                // only release if taken
                if (taken1)
                    rwlock.ExitReadLock();
                taken1 = false;
            }
        });
        reader.Name = "Reader";
        reader.Start();
        Thread.Sleep(1000);
        reader.Interrupt();
        Thread.Sleep(1000);
        rwlock.ExitWriteLock();
        // 2nd taken variable here only so we can see state of taken1
        bool taken2 = taken1;
        while (!taken2)
        {
            taken2 = rwlock.TryEnterReadLock(1000);
            s_logger.Info("2:Enter");
        }
        Thread.Sleep(1000);
    }
