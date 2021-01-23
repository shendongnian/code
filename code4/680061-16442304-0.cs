    private static void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
    {
       try
       {
           MessageQueue mq = (MessageQueue)source;
           Message m = mq.EndReceive(asyncResult.AsyncResult);
           // TODO: Process each message on a separate thread
           // This will immediately queue all items on the threadpool,
           // so there may be more threads spawned than you really want
           // Change how many items are allowed to process concurrently using ThreadPool.SetMaxThreads()
           System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(doWork), m);
           // Restart the asynchronous receive operation.
           mq.BeginReceive();
       }
       catch(MessageQueueException)
       {
           // Handle sources of MessageQueueException.
       }
       return; 
    }
    private static void doWork(object message)
    {
        // TODO: Actual implementation here.
    }
