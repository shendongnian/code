    ReaderWriterLockSlim throttler = new ReaderWriterLockSlim();
    for (int i = 0; i < numWorkers; i++)
    {
        Task.Factory.StartNew(() =>
        {
            foreach (Action nextAction in queue.GetConsumingEnumerable())
            {
                if (mustBeExectutedSerially(nextAction))
                {
                    try
                    {
                        throttler.EnterReadLock();
                        nextAction();
                    }
                    finally
                    {
                        throttler.ExitReadLock();
                    }
                }
                else
                {
                    try
                    {
                        throttler.EnterWriteLock();
                        nextAction();
                    }
                    finally
                    {
                        throttler.ExitWriteLock();
                    }
                }
            }
        });
    }
