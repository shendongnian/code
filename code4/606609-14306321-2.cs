    void Loop()
    {
        TcpListener l = new TcpListener(IPAddress.Any, Port);
        WaitHandle[] h = new WaitHandle[2];
        h[0] = StopEvent;
        WriteInfo("Listening on port {0}", Port);
        l.Start();
        while (true)
        {
            var r = l.BeginAcceptTcpClient(null, null);
            h[1] = r.AsyncWaitHandle;
            // Wait for next client to connect or StopEvent
            int w = WaitHandle.WaitAny(h);
            if (w == 0)  // StopEvent was set (from outside), terminate loop
                break;
            if (w == 1)
            {
                TcpClient c = l.EndAcceptTcpClient(r);
                c.ReceiveTimeout = 90000;
                c.SendTimeout = 90000;
                // client is connected, spawn thread for it and continue to wait for others
                var t = new Thread(ServeClient);
                t.IsBackground = true;
                t.Start(c);
            }
        }
        l.Stop();
        WriteInfo("Listener stopped");
    }
