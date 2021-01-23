    public class ClientHandler {
        
        private static ManualResetEvent _safeForNewThread = new ManualResetEvent(true);
        
        private void HandleRpcRequest(string request)
        {
            
            Thread rpcThread = new Thread(delegate()
            {
                DbRequestProxy dbRequest = null;
                
                try
                {
                    Thread.BeginThreadAffinity();
                    
                    string response = null;
                    
                    // Creates a COM object. The VB6 runtime initializes itself here.
                    // Other threads can be executing here at the same time without fear
                    // of a deadlock, because the VB6 runtime lock is re-entrant.
                    
                    dbRequest = new DbRequestProxy();
                        
                    // Call the COM object
                    response = dbRequest.ProcessDBRequest(request);
                    
                    // Send response back to client
                    _messenger.Send(Messages.RpcResponse(response), true);
                    }
                catch (Exception ex)
                {
                    _messenger.Send(Messages.Error(ex.ToString()));
                }
                finally
                {
                    if (dbRequest != null)
                    {
                        // Force release of COM objects and VB6 globals
                        // to prevent a different deadlock scenario with VB6
                        // and the .NET garbage collector/finalizer threads
                        dbRequest.Dispose();
                    }
                    
                    // Other request threads cannot start right now, because
                    // we're exiting this thread, which will detach the VB6 runtime
                    // when the underlying native thread exits
                    
                    _safeForNewThread.Reset();
                    Thread.EndThreadAffinity();
                }
            });
            
            // Make sure we can start a new thread (i.e. another thread
            // isn't in the middle of exiting...)
            
            _safeForNewThread.WaitOne();
            
            // Put the thread into an STA, start it up, and wait for
            // it to end. If other requests come in, they'll get picked
            // up by other thread-pool threads, so we won't usually be blocking anyone
            // by doing this (although we are blocking a thread-pool thread, so
            // hopefully we don't block for *too* long).
            rpcThread.SetApartmentState(ApartmentState.STA);
            rpcThread.Start();
            rpcThread.Join();
            
            // Since we've joined the thread, we know at this point
            // that any DLL_THREAD_DETACH notifications have been handled
            // and that the underlying native thread has completely terminated.
            // Hence, other threads can safely be started.
            
            _safeForNewThread.Set();
            
        }
    }
