    IPEndPoint myEndpoint = new IPEndPoint(IPAddress.Parse(_serverAddress), _port);
     _serverSocket = new Socket(myEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    
     _serverSocket.Bind(myEndpoint);
     _serverSocket.Listen((int)SocketOptionName.MaxConnections);
    
    _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), _serverSocket);
    
    .....
    
    
    private void AcceptCallback(IAsyncResult result)
            {
                ConnectionInfo connection = new ConnectionInfo();
                try
                {
                    Socket s = (Socket)result.AsyncState;
                    connection.Socket = s.EndAccept(result);
    
                    connection.Buffer = new byte[1024];
                    connection.Socket.BeginReceive(connection.Buffer,
                        0, connection.Buffer.Length, SocketFlags.None,
                        new AsyncCallback(ReceiveCallback),
                        connection);
                }
                catch (SocketException exc)
                {
                    CloseConnection(connection, "Exception in Accept");
                }
                catch (Exception exc)
                {
                    CloseConnection(connection, "Exception in Accept");
                }
                finally
                {
    
                        _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), result.AsyncState);
                }
            }
