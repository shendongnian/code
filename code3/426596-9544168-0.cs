        private static ManualResetEvent _safeForNewThread = new ManualResetEvent(true);
        private void HandleRpcRequest(string request)
        {
            Thread rpcThread = new Thread(delegate()
            {
                DbRequestProxy dbRequest = null;
                try
                {
                    Thread.BeginThreadAffinity();
                    string response = "";
                    dbRequest = new DbRequestProxy();
                    _safeForNewThread.Set();
                    response = dbRequest.ProcessDBRequest(request);
                    // Response can't be null
                    if (response == null)
                    {
                        response = "";
                    }
                    _messenger.Send(Messages.RpcResponse(response), true);
                }
                catch (Exception ex)
                {
                    Console.Write("RPC Error: {0}", ex.ToString());
                    _messenger.Send(Messages.Error(ex.ToString()));
                }
                finally
                {
                    if (dbRequest != null)
                    {
                        dbRequest.Dispose();
                    }
                    _safeForNewThread.Reset();
                    Thread.EndThreadAffinity();
                }
            });
            _safeForNewThread.WaitOne();
            rpcThread.SetApartmentState(ApartmentState.STA);
            rpcThread.Start();
            rpcThread.Join();
            _safeForNewThread.Set();
        }
