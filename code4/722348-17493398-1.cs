    CancellationToken ct; //passed in
    ct.Register(() => myHttpContent.Dispose()); 
    string content;
    try
    {
        content = await myHttpContent.ReadAsStringAsync();
    }
    catch(Exception) //suspect an ObjectDisposedException, but worth checking
    {
        if(ct.IsCancellationRequested)
        {
            //cancellation was requested
            //underlying stream is already closed by the Dispose call above
        }
    }
    
