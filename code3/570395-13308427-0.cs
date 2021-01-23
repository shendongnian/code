    public string GetFromTextCommand(string command)
        {
            try
            {
                if (!_isConnected)
                    Connect();
                if (!_isConnected)
                    return null;
                SendTextCommand(command);
                string response = GetFromTextCommand();
                if (response.StartsWith("202"))
                {
                    while (!response.EndsWith(".\r\n"))
                    {
                        string newResponse = GetFromTextCommand();
                        response += newResponse;
                    }
                }
                return response;
            }
            catch (Exception ex) { GenerateException(ex.Message); return null; }
        }
        public string GetFromTextCommand()
        {
            try
            {
                if (!_isConnected)
                    Connect();
                if (!_isConnected)
                    return null;
                string response = "";
                SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();
                socketEventArg.RemoteEndPoint = _socket.RemoteEndPoint;
                socketEventArg.UserToken = null;
                socketEventArg.SetBuffer(new Byte[MAX_BUFFER_SIZE], 0, MAX_BUFFER_SIZE);
                socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(delegate(object s, SocketAsyncEventArgs e)
                {
                    if (e.SocketError == SocketError.Success)
                    {
                        response = Encoding.ASCII.GetString(e.Buffer);
                        response = response.Trim('\0');
                    }
                    else
                        throw new Exception(e.SocketError.ToString());
                    _pausingThread.Set();
                });
                _pausingThread.Reset();
                _socket.ReceiveAsync(socketEventArg);
                _pausingThread.WaitOne(TIMEOUT_MILLISECONDS);
                return response;
            }
            catch (Exception ex) { GenerateException(ex.Message); return null; }
        }
