    void IDisposable.Dispose()
    {   
         Close();
    }
    
    void Close() 
    {
        _messages.CompleteAdding();
        _worker.Join(); // Wait for the consumer's thread to finish.
        //Some logic on closing log file
    }
