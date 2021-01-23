    while (true)
            {
                // Set the event to nonsignaled state.
                allDone.Reset();                    
                // Start an asynchronous socket to listen for connections.
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                // Wait until a connection is made before continuing.
                allDone.WaitOne();
            }
