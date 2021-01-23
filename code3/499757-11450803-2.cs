    while(this.isServerRunning)
    {
         var pipeClientConnection = new NamedPipeServerStream(...);
         try
         {
             pipeClientConnection.WaitForConnection();
         }
         catch(...)
         {
             ...
             continue;
         }
         ThreadPool.QueueUserWorkItem(state =>
              {
                   // we need a separate variable here, so as not to make the lambda capture the pipeClientConnection variable, which is not recommended in multi-threaded scenarios
                   using(var pipeClientConn = (NamedPipeServerStream)state)
                   {
                        // do stuff
                        ...
                   }
              }, pipeClientConnection);
    }
