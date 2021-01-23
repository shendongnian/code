     socket.OnMessage = message =>
     {
         foreach (IWebSocketConnection socketConnection in allSockets.Where(socketConnection => socket.ConnectionInfo.ClientIpAddress != socketConnection.ConnectionInfo.ClientIpAddress))
         {
             socketConnection.Send("Echo: " + message);
         }
     };
