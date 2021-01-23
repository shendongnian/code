    // semi - pseudo-code
    
    // Infrastructure – reads messages from the queue 
    //    (independent thread, could be a triggered by a timer)
    while(count < maxCount && (message = Queue.GetMessage()) != null)
    {
        Interlocked.Increment(ref count);
    
      // process message asynchronously on a new thread
      Task.Factory.StartNew(() => ProcessWrapper(message));		
    }
    
    // glue
    void ProcessWrapper(Message message)
    {
       try
       {
          Process(message);
          Queue.DeleteMessage(message);
       }
       catch(Exception ex)
       {
          // Handle exception here.
          // Log, write to poison message queue etc ...
       }
       finally 
       {
          Interlocked.Decrement(ref count)
       }
    }
    
    // business process
    Void Process(Message message)
    {
     …
    }
