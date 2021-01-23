    private object _lock;
    
    public static void AddEvent(EventRecord record)
    {
        lock (_lock)
        {
            record.EventDate = DateTime.Now;
            s_listEvents.Add(record);
        }
    }
