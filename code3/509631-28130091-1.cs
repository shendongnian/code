    QueueItem item = _Queue.Dequeue(); // Or TryDequeue if you use a concurrent dictionary
    if (!item.IsRemoved)
    {
        // Do work here
    }
