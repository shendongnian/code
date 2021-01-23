        while (!this.disposed)
        {
            Thread.Sleep(1); // to avoid spinning a core 100%
            if (this.tcpListener.Pending)
            {
                // shouldn't block because we checked tcpListener.Pending
                var client = this.tcpListener.AcceptTcpClient();
                var clientThread = new Thread(this.HandleClientComm);
                clientThread.Start(client);
            }
        }
