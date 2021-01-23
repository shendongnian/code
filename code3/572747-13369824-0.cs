    var queue = new BlockingCollection<Action>();
    
    int numWorkers = 3;
    Semaphore throttler = new Semaphore(numWorkers, numWorkers);
    
    
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
                        for (int j = 0; j < numWorkers; j++)
                        {
                            throttler.WaitOne();
                        }
    
                        nextAction();
                    }
                    finally
                    {
                        throttler.Release(numWorkers);
                    }
                }
                else
                {
                    try
                    {
                        throttler.WaitOne();
                        nextAction();
                    }
                    finally
                    {
                        throttler.Release();
                    }
                }
            }
        });
    }
