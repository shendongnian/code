            var client = new TcpClient();
            var result = client.BeginConnect("remotehost", Port, null, null);
           
            result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
            if (!client.Connected)
            {
                throw new Exception("Failed to connect.");
            }
            // we have connected
            client.EndConnect(result);
