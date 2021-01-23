    AutoResetEvent consumerEvent = new AutoResetEvent(false);
    AutoResetEvent producerEvent = new AutoResetEvent(false);
    // producer code
    while(/* lines still available */)
    {
        // read 500 lines
        // write to shared file
        consumerEvent.Set(); // signal consumer thread
        producerEvent.WaitOne(); // wait to be signaled to continue
    }
