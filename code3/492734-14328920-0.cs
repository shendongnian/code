     var socket = new Socket(AddressFamily.InterNetwork, 
                            SocketType.Stream, ProtocolType.Tcp);
      
     // ...
     
     socket.BeginReceive(recvBuffer, 0, recvBuffer.Length, 
                         SocketFlags.None, ReceiveCallback, null);
     
     void ReceiveCallback(IAsyncResult result)
     {
       var bytesReceived = socket.EndReceive(result);
       if (bytesReceived > 0) { // Handle received data here. }
       if (socket.Connected)
       {
         // Keep receiving more data...
         socket.BeginReceive(recvBuffer, 0, recvBuffer.Length, 
                             SocketFlags.None, ReceiveCallback, null);
       }
     }
