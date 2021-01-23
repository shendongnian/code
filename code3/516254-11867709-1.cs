        while (true)
        {
            lock(lockObj)
            {
                if (Queue.Count <= 0)
                {
                    Monitor.Wait(lockObj);
                }
                object anObject = Queue.Dequeue();
            }
        }
