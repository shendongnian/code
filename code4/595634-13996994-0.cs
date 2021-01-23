    private void HandleClients(object newClient)
            {
                //check to see if we are adding a new client, or just iterating through existing clients
                if (newClient != null)
                {
                    TcpClient newTcpClient = (TcpClient)newClient;
    
                    //add this client to our list
                    clientList.Add(newTcpClient.Client.Handle, newTcpClient);
                    Console.WriteLine("Adding handle: " + newTcpClient.Client.Handle);  //for debugging
                }
    
                //iterate through existing clients to see if there is any data on the wire
                foreach (TcpClient tc in clientList.Values)
                {
                    if (tc.Available > 0)
                    {
                        int dataSize = tc.Available;
                        Console.WriteLine("Received data from: " + tc.Client.Handle); //for debugging
    
                        string text = GetNetworkString(tc.GetStream());
                        
                        //and transmit it to everyone else
                        foreach (TcpClient otherClient in clientList.Values)
                        {
                            if (tc.Client.Handle != otherClient.Client.Handle)
                            {
                                Send(otherClient.GetStream(), text);
                            }
                        }
                    }
                }
            }
    
            public void Send(NetworkStream ns, string data)
            {
                try
                {
                    byte[] bdata = GetBytes(data, Encoding.ASCII);
                    ns.Write(bdata, 0, bdata.Length);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
    
            protected string GetNetworkString(NetworkStream ns)
            {
                if (ns.CanRead)
                {
                    string receivedString;
                    byte[] b = GetNetworkData(ns);
    
                    receivedString = System.Text.Encoding.UTF8.GetString(b);
                    log.Info("Received string: " + receivedString);
    
                    return receivedString;
                }
                else
                    return null;
            }
    
            protected byte[] GetNetworkData(NetworkStream ns)
            {
                if (ns.CanRead)
                {
                    log.Debug("Data detected on wire...");
                    byte[] b;
                    byte[] myReadBuffer = new byte[1024];
                    MemoryStream ms = new MemoryStream();
                    int numberOfBytesRead = 0;
    
                    // Incoming message may be larger than the buffer size.
                    do
                    {
                        numberOfBytesRead = ns.Read(myReadBuffer, 0, myReadBuffer.Length);
                        ms.Write(myReadBuffer, 0, numberOfBytesRead);
                    }
                    while (ns.DataAvailable);
    
                    //and get the full message
                    b = new byte[(int)ms.Length];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(b, 0, (int)ms.Length);
                    ms.Close();
    
                    return b;
                }
                else
                    return null;
            }
