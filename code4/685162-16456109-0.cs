    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clientSocket.Connected)
                    clientSocket.Connect(IPAddress.Parse("192.168.1.3"), 8222);
                clientSocket.Send(Encoding.UTF8.GetBytes("Esto es una prueba"));
                clientSocket.Disconnect(true);
                clientSocket.Close();
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //You need to close the send code
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
