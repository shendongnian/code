    // Start 10 threads
    Parallel.For(0, 10, (i) =>
    {
      while (true)
      {
        // Get message from queue
        var msg = Queue.GetMessage();
        if (msg != null)
        {
          // Do some work here...
          StartSomeJob();
          
          // Then when you are done, delete the message
          Queue.DeleteMessage(msg);
        }
        // Wait 1 second before fetching next work item from queue
        System.Threading.Thread.Sleep(1000);
      }
    });
