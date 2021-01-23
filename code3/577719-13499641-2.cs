    void Process(int retries = 0) 
    {
        foreach (var connection in _connections) 
        {
            if(Monitor.TryEnter(connection))
            {
                try
                {
                    //Dequeue the next request
                    var calcEnginePool = _pendingPool.Dequeue();
    
                    //Perform the operation and exit.
                    connection.RunCalc(calcEnginePool);
                }
                finally
                {
                    // Release the lock
                    Monitor.Exit(connection);
                }
                return;
            }
        }
        
        if (retries < 10)
        {
            Thread.Sleep(200);
            Process(retries+1);
        }
    }
