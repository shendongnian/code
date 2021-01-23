            Socket clientSocket = serverSocket.EndAccept(ar); 
            clientSocketList.Add(clientSocket);
            AppendToTextBox("ClientConnected");
            var buffer = new byte[BUFFER_LENGTH];  // <---
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
