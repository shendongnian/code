    public void DispatchWork(IEnumerable<string> worklist)
        {
            var resetEvents = new List<ManualResetEvent>();
            var batch = 100;
            foreach (work in worklist)
            {
                var resetEvent = new ManualResetEvent(false);
                resetEvents.Add(resetEvent);
                ThreadPool.QueueUserWorkItem((a) =>
                {
                    try
                    {
                        // do work
                    }
                    catch (Exception e)
                    {
                        // do something
                        throw;
                    }
                    finally
                    {
                        if (resetEvent != null) resetEvent.Set();
                    }
                });
            }
            foreach (var resetEvent in resetEvents)
            {
                resetEvent.WaitOne();
                resetEvent.Dispose(); // todo: use try-finally
            }
            resetEvents.Clear();
        }
