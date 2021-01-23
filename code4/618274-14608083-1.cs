    int i = serverSock.EndReceive(ar);
    if (i > 0)
        {
            serverSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, 0, 
            	                     new AsyncCallback(callback), null);
        }
    else
        {
            serverSock.Close();
        }
