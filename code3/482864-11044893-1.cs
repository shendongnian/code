     IPEndPoint myEndpoint = new IPEndPoint(IPAddress.Parse(_serverAddress), _port);
     _serverSocket = new Socket(myEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    
     _serverSocket.Bind(myEndpoint);
     _serverSocket.Listen((int)SocketOptionName.MaxConnections);
    
    acceptThread = new Thread(new ThreadStart(ExecuteAccept));
    acceptThread.Start();
    
    ......
    
    private void ExecuteAccept()
            {
    
                while (true)
                {
    
                    ConnectionInfo connection = new ConnectionInfo();
                    try
                    {
                        connection.Socket = _serverSocket.Accept();
                        
                        connection.Buffer = new byte[1024];
                        connection.Socket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), connection);
                    }
                    catch (SocketException exc)
                    {
                        CloseConnection(connection, "Exception in Accept");
                    }
                    catch (Exception exc)
                    {
                        CloseConnection(connection, "Exception in Accept");
                    }
                }
            }
