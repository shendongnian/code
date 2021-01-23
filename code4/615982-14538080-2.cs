    public T Dequeue()
    {
        return Dequeue(TimeSpan.Zero);
    }
    
    public T Dequeue(TimeSpan timeout)
    {
        DateTime startTime = DateTime.Now;
    
        do
        {
            DateTime now = DateTime.Now;
    
            var item = items.FirstOrDefault(i => i.ReadyTime <= now);
            if (item == null)
                continue;
    
            items.Remove(item);
            return item.Value;
        }
        while (DateTime.Now - startTime < timeout);
            
        return default(T);
    }
