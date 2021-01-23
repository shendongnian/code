    BlockingCollection<Exception> bc = new BlockingCollection<Exception>();
    
    // thread A - Producer
    try
    {
        ...
    }
    catch(Exception ex)
    {
        bc.Add(ex);
    }
    
    
    //thread B - Consumer
    try
    {
        // Consume bc
        while (true)
        {
            var ex = bc.Take();
            //thread sleep
        }
    }
    catch (InvalidOperationException)
    {
        // IOE means that Take()
        // was called on a completed collection and no
        // No more exceptions, restart checking    
    }
