         TcpClient clientSocket = default(TcpClient);
                serverSocket.Start();
    
                while(True)
    {clientSocket = serverSocket.AcceptTcpClient()
                requestCount = 0;
                while ((clientSocket.Connected == true))
                {
                    try
                    {
                        requestCount = requestCount + 1;
                        NetworkStream networkStream = clientSocket.GetStream();
                        string serverResponse = Request.QueryString["id"] + ";" + Credenciada.ToString() + ".";
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);                          
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();                    
                    }
                    catch (Exception ex)
                    {                    
                    }
                }
    }
