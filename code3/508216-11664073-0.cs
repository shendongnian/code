    private void AcceptClientAndProcess()
    {
        try
        {
            client = server.Accept();
            client.ReceiveTimeout = 20000;
        }
        catch
        {
            return;
        }
    
        while (true)
        {
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int read = 0;
    
            try
            {
                read = client.Receive(buffer);
            }
            catch
            {
                break;
            }
    
            if (read > 0)
            {
                //Handle data
            }
            else
            {
                break;
            }
        }
    
        if (client != null)
            client.Close(5000);
    }
