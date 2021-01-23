    while (true)
        {
            lock (lockObject)
            {
                if (inQueue.Count == 0)
                {
                    Monitor.Wait(lockObject);
                    continue;
                }                
                image = inQueue.Dequeue();   
            }
            // Do some heavy processing with the image
            
            lock (lockObject)
            {
                outQueue.Enqueue(image);
            }
        }
