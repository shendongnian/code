    private static ManualResetEvent _processingDone = new ManualResetEvent( false );
    //Introduce an internal property ProcessingDone to access _processingDone 
    //This should be in a class to which you can access both from 'Form1' and the class containing ReceiveCallBack
    //In ReceiveCallBack
    if (connectionData.SuccessHandler != null)
    {
        connectionData.SuccessHandler(client);
        ProcessingDone.WaitOne();
        client.BeginReceive(connectionData.clientObj.buffer, 0, ClientStateObject.bufSize, 0, new AsyncCallback(ReceiveCallback), connectionData);
    }
