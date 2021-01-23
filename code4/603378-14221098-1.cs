    void WaitForData(SocketState state)
    {
      try
      {
        state.Socket.BeginReceive(state.DataBuffer, 0, state.DataBuffer.Length, SocketFlags.None, new AsyncCallback(ReadDataCallback), state);
      }
      catch (SocketException se)
      {
        //Socket has been closed  
        //Close/dispose of socket
      }
    }
    public void ReadDataCallback(IAsyncResult ar)
    {
      SocketState state = (SocketState)ar.AsyncState;
      try
      {
        // Read data from the client socket.
        int iRx = state.Socket.EndReceive(ar);
               
        //Handle Data....
        WaitForData(state);
      }
      catch (ObjectDisposedException)
      {
        //Socket has been closed  
        //Close/dispose of socket
      }
      catch (SocketException)
      {
        //Socket exception
        //Close/dispose of socket
      }
    }
