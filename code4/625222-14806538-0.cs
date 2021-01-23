    public void Flush()
    {
        if (messages.Count == 0)
            return;
        
        // make a copy of the list.
        var currentMessages = messages.ToList();
        Task.Factory.StartNew(() => FlushData(currentMessages));
        messages.Clear();// clear the messages to record new set of messages before writing.
    }
    protected virtual void FlushData(IEnumerable<LogMessage> toBeFlushed)
    {
        if (!IsEnabled) // logs enabled or not.
        {
            return;
        }
        IEnumerable<LogMessage> temp = toBeFlushed.OrderBy(msg => msg.TimeStamp).ToArray();
        this.flush(temp);
    }
