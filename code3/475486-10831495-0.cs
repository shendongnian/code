    public IAsyncResult BeginRead(AsyncCallback callback)
    // Calculate whether to read length header or remaining payload bytes
    // Issue socket recieve and return its IAsyncResult
    
    public MemoryStream EndRead(IAsyncResult result)
    // Process socket read, if payload read completely return as a memorystream
    // If length header has been recieved make sure buffer is big enough
    // If 0 bytes recieved, throw SocketException(10057) as conn is closed
    
    public IAsyncResult BeginSend(AsyncCallback callback, MemoryStream data)
    // Issue sends for the length header or payload (data.GetBuffer()) on the first call
    
    public Boolean EndSend(IAsyncResult result)
    // Process bytes sent, return true if payload sent completely.
    // If 0 bytes sent, throw SocketException(10057)
    
