    public void ProcessQueue()
    {
        QueueItem item;
        while (!IsCancelled && queue.TryTake(out item, Timeout.Infinite))
        {
            item.FuncToExecute();
            if (item.OptionalCallback != null)
            {
                item.OptionalCallback();
            }
        }
    }
