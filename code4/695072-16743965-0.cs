    //setup broadcast client
    broadcastClient = new UdpClient(5454);
    broadcastAddress = new IPEndPoint(IPAddress.Broadcast, 8888);
    broadcastClient.Connect(broadcastAddress);
    //send and immediately close
    byte[] text_to_send = Encoding.ASCII.GetBytes("networkinfo");
    broadcastClient.Send(text_to_send, text_to_send.Length);
    broadcastClient.Close();
    
    //open up new client to receive
    UdpClient receivingClient = new UdpClient(5454);
    IPEndPoint serverResponse = new IPEndPoint(IPAddress.Any, 0);
    byte[] message = receivingClient.Receive(ref serverResponse);
    string messageReceived = Encoding.ASCII.GetString(message);
    Debug.WriteLine(messageReceived);
