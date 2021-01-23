        while (true)
        {
            Monitor.Enter(lockObj);
            try
            {
                if (Queue.Count <= 0)
                {
                    Monitor.Wait(lockObj);
                }
                object anObject = Queue.Dequeue();
            }
            finally
            {
                Monitor.Exit(lockObj);
            }
        }
