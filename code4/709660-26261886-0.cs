        private class State
        {
            public TcpClient Client { get; set; }
            public bool Success { get; set; }
        }
        public TcpClient Connect(string hostName, int port, int timeout)
        {
            var client = new TcpClient();
            //when the connection completes before the timeout it will cause a race
            //we want EndConnect to always treat the connection as successful if it wins
            var state = new State { Client = client, Success = true };
            IAsyncResult ar = client.BeginConnect(hostName, port, EndConnect, state);
            state.Success = ar.AsyncWaitHandle.WaitOne(timeout, false);
            if (!state.Success || !client.Connected)
                throw new Exception("Failed to connect.");
            return client;
        }
        void EndConnect(IAsyncResult ar)
        {
            var state = (State)ar.AsyncState;
            TcpClient client = state.Client;
            try
            {
                client.EndConnect(ar);
            }
            catch { }
            if (client.Connected && state.Success)
                return;
            client.Close();
        }
