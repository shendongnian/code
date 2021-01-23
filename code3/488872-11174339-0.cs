    TcpClient client = new TcpClient();
    client.BeginConnect("server", 5555, new AsyncCallback(CallBack), client);
    private void CallBack(IAsyncResult result)
    {
     bool connected = false;
     using (TcpClient client = (TcpClient)result.AsyncState)
     {
        try
        {
            client.EndConnect(result);
            connected = client.Connected;
        }
        catch (SocketException)
        {
        }
     }
     if (connected)
     {
        this.Invoke((MethodInvoker)delegate
        {
            // Do Something
        });
     }
     else
     {
        this.Invoke((MethodInvoker)delegate
        {
            // Do Something
        });
     } 
    }
