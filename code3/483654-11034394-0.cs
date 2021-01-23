    public int GetHashCode(List<EventLogEntry> obj)
    {
        int total = 0;
        foreach (var eventLogEntry in obj)
        {
            total ^= GetHashCode(eventLogEntry);
        }
        
        return total;
    }
