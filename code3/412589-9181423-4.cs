    public void Start()
    {
        var server= new NamedPipeServerStream("TempPipe", 
                                              PipeDirection.In,
                                              254, 
                                              PipeTransmissionMode.Message, 
                                              PipeOptions.Asynchronous);
    				
    	// If nothing ever connects, the callback will never be called.
        server.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), this);
    
    	// ... arbitrary code
    // EndWaitForConnection() was not the right answer here, it would just wait indefinitely
    // if you called it.  As Hans Passant mention, its meant to be used in the callback. 
    // Which it now is. Instead, we are going to close the pipe.  This will trigger 
    // the callback to get called.  
    // However, the EndWaitForConnection() that will excecute in the callback will fail
    // with an exception since the pipe is closed by time it gets invoked, 
    // thus you must capture it with a try/catch
    	
    	server.Close();	// <--- effectively closes our pipe and gets our 
                            //       BeginWaitForConnection() moving, even though any future 
                            //       operations on the pipe will fail.
    }
