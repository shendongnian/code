    private void ExecuteMTAAction(Action action)
    {
        if (IsMTAThread)
            action();
        else
        {
            lock (queueLockObj)
            {
                MarshalThreadItem item = new MarshalThreadItem();
                item.Action = action;
                item.waitHandle = new ManualResetEvent(false); //setup
                marshalThreadItems.Enqueue(item);
    
                Monitor.Pulse(queueLockObj);
            }
                item.waitHandle.WaitOne(); //waiting           
        }
    }
