    void QueueProc(object state)
    {
        while (eventQueue.Count > 0 && eventQueue.Peek().dueTime < ApplicationTime.Elapsed)
        {
            AccountEvent ev = eventQueue.Dequeue();
            // process item. See comments below.
        }
        // reset the timer so that it will fire in five seconds
        eventTimer.Change(TimeSpan.FromSeconds(5), TimeSpan.Infinite);
    }
