    // Create the listener.
    var tcpListener = new TcpListener(connection);
    
    // Start.
    tcpListener.Start();
    
    // The CancellationToken.
    var cancellationToken = ...;
    
    // Have to wait on an OperationCanceledException
    // to see if it was cancelled.
    try
    {
        // Wait for the client, with the ability to cancel
        // the *wait*.
        var client = await tcpListener.AcceptTcpClientAsync().
            WithWaitCancellation(cancellationToken);
    }
    catch (AggregateException ae)
    {
        // Async exceptions are wrapped in
        // an AggregateException, so you have to
        // look here as well.
    }
    catch (OperationCancelledException oce)
    {
        // The operation was cancelled, branch
        // code here.
    }
