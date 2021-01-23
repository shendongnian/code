    public void SendCode(string ipAddress, string zplCode)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;
            IPAddress ip = IPAddress.Parse(ipAdress);
            IPEndPoint ipep = new IPEndPoint(ip, 9100);
            clientSocket.Connect(ipep);
            byte[] stringBytes = Encoding.UTF8.GetBytes(zplCode);
            clientSocket.Send(stringBytes);
            clientSocket.Close();
        }
