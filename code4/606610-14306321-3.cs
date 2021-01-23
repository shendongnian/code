        void ServeClient(object State)
        {
            TcpClient c = (TcpClient)State;
            NetworkStream s = c.GetStream();
            try
            {
                 // Communicate with your client
            }
            finally
            {
                s.Close();
                c.Close();
            }
        }
