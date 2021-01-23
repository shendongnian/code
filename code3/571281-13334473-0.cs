    public void BeginSending() // invoked by outThread
    {
        while (true)
        {
            resetEvent.WaitOne();
            while (messageQueue.Count > 0)
            {
                byte[] msg;
                messageQueue.TryDequeue(out msg);
                // send msg via socket
            }
    
        // context change
        messageQueue.Enqueue(msg);
        resetEvent.Set();
        // context change
    
            resetEvent.Reset();
        }
    }
