    public static void ReadCallback(IAsyncResult ar)
    {
        String content = String.Empty;
        // Retrieve the state object and the handler socket from the asynchronous state object.
        StateObject state = (StateObject)ar.AsyncState;
        Socket handler = state.workSocket;
        if (handler != null && !handler.Poll(1, SelectMode.SelectRead) && handler.Connected && handler.Available == 0)
        {
            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                // Parsing data received in here..
                // Enabled received for next data
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
        }
        else
        {
            if (handler.Connected)
            {
                // Client are offline will be detected here
                IPEndPoint clientIP = handler.RemoteEndPoint as IPEndPoint;
                MessageBox.Show(String.Format("IP Client: {0}:{1} disconnected", clientIP.Address, clientIP.Port));
            }
            {
                // Server are offline will be detected here
            }
        }
    }
