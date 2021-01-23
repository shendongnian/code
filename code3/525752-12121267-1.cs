    Foo item;
    lock(someMonitor)
    {
        // Broken!
        if (queue.Count == 0)
        {
            Monitor.Wait(someMonitor);
        }
        item = queue.Dequeue();
    }
    // Use the item
