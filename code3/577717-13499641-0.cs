    void Process(int retries = 0) 
    {
        foreach (var connection in _connections) 
        {
            if(Monitor.TryEnter(connection))
            {
                 //Dequeue the next request
                var calcEnginePool = _pendingPool.Dequeue();
    
                //Perform the operation and exit.
                connection.RunCalc(calcEnginePool);
                
                // Release the lock
                Monitor.Exit(connection);
                
                // Exit
                return;
            }
        }
        
        if (retries < 10)
        {
            retries += 1;
            Thread.Sleep(200);
            Process(retries);
        }
    }
