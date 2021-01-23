    public void StartListening()
    {
        ThreadPool.QueueUserWorkItem((object state) => 
        {
            allDone.Reset();
            //Inform on the console that the socket is ready
            Console.WriteLine("Waiting for a connection...");
            /* Waits for a connection and accepts it. AcceptCallback is called and the
            * actual socket passed as AsyncResult
            */
            listener.BeginAcceptTcpClient(new AsyncCallback(AcceptCallback), listener);
            if (this.StartupComplete != null)
            {
                StartupComplete();
            }
            
            allDone.WaitOne();
        });
    }
