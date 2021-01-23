    if(TestConnection("smtpServerAddress",port))
      SendEmail();
    public static bool TestConnection(string smtpServerAddress, int port)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(smtpServerAddress);
            IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], port);
            using (Socket tcpSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            {
                //try to connect and test the rsponse for code 220 = success
                tcpSocket.Connect(endPoint);
                if (!CheckResponse(tcpSocket, 220))
                {
                    return false;
                }
    
                // send HELO and test the response for code 250 = proper response
                SendData(tcpSocket, string.Format("HELO {0}\r\n", Dns.GetHostName()));
                if (!CheckResponse(tcpSocket, 250))
                {
                    return false;
                }
    
                // if we got here it's that we can connect to the smtp server
                return true;
            }
        }
      private static bool CheckResponse(Socket socket, int expectedCode)
    {
        while (socket.Available == 0)
        {
            System.Threading.Thread.Sleep(100);
        }
        byte[] responseArray = new byte[1024];
        socket.Receive(responseArray, 0, socket.Available, SocketFlags.None);
        string responseData = Encoding.ASCII.GetString(responseArray);
        int responseCode = Convert.ToInt32(responseData.Substring(0, 3));
        if (responseCode == expectedCode)
        {
            return true;
        }
        return false;
    }
