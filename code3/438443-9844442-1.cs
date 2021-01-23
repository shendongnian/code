    // Process the accept for the socket listener.
    private void ProcessAccept(SocketAsyncEventArgs e)
    {
        Socket s = e.AcceptSocket;
        if (s.Connected)
        {
            try
            {
                SocketAsyncEventArgs readEventArgs = this.readWritePool.Pop();
                if (readEventArgs != null)
                {
                    // Get the socket for the accepted client connection and put it into the 
                    // ReadEventArg object user token.
                    readEventArgs.UserToken = new Token(s, this.bufferSize);
    
                    Interlocked.Increment(ref this.numConnectedSockets);
                    Console.WriteLine("Client connection accepted. 
    			There are {0} clients connected to the server",
                        this.numConnectedSockets);
    
                    if (!s.ReceiveAsync(readEventArgs))
                    {
                        this.ProcessReceive(readEventArgs);
                    }
                }
                else
                {
                    Console.WriteLine("There are no more available sockets to allocate.");
                }
            }
            catch (SocketException ex)
            {
                Token token = e.UserToken as Token;
                Console.WriteLine("Error when processing data received from {0}:\r\n{1}", 
    			token.Connection.RemoteEndPoint, ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
    
            // Accept the next connection request.
            this.StartAccept(e);
        }
    }
