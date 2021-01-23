    private void MainCode()
    {
        using (TcpClient client = new TcpClient())
        {
            client.Connect(IPAddress.Parse("127.0.0.1"), 8000);
            
            while(variableThatRepresentsRunning)
            {
                //(Snip logic that gererates the message)
    
                clietnRequest(message, ref response, client);
                //(Snip more logic)
            }
        }
    }
    
    private static void clietnRequest(string message,ref string response, TcpClient client)
    {
        if (client.Connected)
        {
            using (NetworkStream networkStream = client.GetStream())
            {
                using (BinaryWriter writer = new BinaryWriter(networkStream))
                {
                    writer.Write(Responses.RequestConnect);
                    using (BinaryReader reader = new BinaryReader(networkStream))
                    {
                        if (reader.ReadString() == Responses.AcknowledgeOK)
                        {
                            response = Responses.AcknowledgeOK;
    
                        }
                    }
                }
            }
        }
        else
        {
            //Show some error because the client was not connected
        }
    }
