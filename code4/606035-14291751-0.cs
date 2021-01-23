    private void OnReceive(IAsyncResult result)
    {
        try
        {
            Socket clientSocket = (Socket)result.AsyncState;
            clientSocket.EndReceive(result);
    
            command = responseMessage = string.Empty;
            command = ByteToString(receviedData);
            receviedData = new byte[30];
    
            if (command=="Connect")
            {
                ClientInfo clientInfo = new ClientInfo() {
                   socket = clientSocket,
                   IP = clientSocket.RemoteEndPoint.ToString(),
                   }; 
                connectedClients.Add(clientInfo);
                responseMessage = "Connection established...";
            }
            else if (command=="Disconnect")
            {
                removeClientInfo(clientSocket);
                clientSocket.Close();
            }
            else
            {
                responseMessage = "Error";
            }
    
            byte[] responseStatus = StringToByte(responseMessage);
            for (int i = 0; i < connectedClients.Count; i++)
            {
                if (connectedClients[i].socket==clientSocket)
                {
                    connectedClients[i].socket.BeginSend(responseStatus, 0, responseStatus.Length,SocketFlags.None, new AsyncCallback(OnSend), connectedClients[i].socket);
                    break;
                }
            }
    
        }
        catch(Exception ex)
        {
          // add error handling and gracefully recover
          removeClientInfo((Socket)result.AsyncState);
        }
    }
    
    /// removes the client info from the connectedClients enumerable
    private void removeClientInfo(Socket socket)
    {
    	for (int i = 0; i < connectedClients.Count; i++)
    	{
    		if (connectedClients[i].socket == socket)
    		{
    			connectedClients.RemoveAt(i);
    			break;
    		}
    	}
    }
