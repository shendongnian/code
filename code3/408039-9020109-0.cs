        while (true)
        {
            try
            {
                int count = 0;
                lock(locker)
                   count= queue.Count;
                if (count == 0)
                {
                    timer.Change(waitTime, 0);
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (ThreadInterruptedException)
            {
            }
            while (queue.Count != 0)
            {
                lock (locker)
                {
                    deliver(queue.Dequeue());
                }
            }
        }
    }
