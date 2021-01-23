    try
    {
        TcpClient client = new TcpClient("remotehost", this.Port);
        Byte[] data = System.Text.Encoding.Unicode.GetBytes(this.Message);
        NetworkStream stream = client.GetStream();
        stream.WriteTimeout = 1000; //  <------- 1 second timeout
        stream.ReadTimeout = 1000; //  <------- 1 second timeout
        stream.Write(data, 0, data.Length);
        data = new Byte[512];
        Int32 bytes = stream.Read(data, 0, data.Length);
        this.Response = System.Text.Encoding.Unicode.GetString(data, 0, bytes);
        stream.Close();
        client.Close();    
        FireSentEvent();  //Notifies of success
    }
    catch (Exception ex)
    {
        // Throws IOException on stream read/write timeout
        FireFailedEvent(ex); //Notifies of failure
    }
