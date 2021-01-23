    void ConsumerThread()
    {
        while (ShouldRun)
        {
            // wait to be notified
            _signal.Wait();
        
            Item item = null;
            do
            { 
               item = null;
               // fetch the item,
               // but only lock shortly
               lock (_lock)
               {
                   if (_queue.Count > 0)
                      item = _queue.Dequeue(item);
               }
            
               if (item != null)
               {
                  // do stuff
               }            
            }
            while (item != null); // loop until there are items to collect
        }
    }
    
