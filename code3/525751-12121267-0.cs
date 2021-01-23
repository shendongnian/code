    Foo item;
    lock(someMonitor)
    {
        while (queue.Count == 0)
        {
            Monitor.Wait(someMonitor);
        }
        item = queue.Dequeue();
    }
    // Use the item
