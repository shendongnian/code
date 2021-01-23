    public void SendMessage(TcpClient client, string message)
    {
        //byte[] buffer = Encoding.ASCII.GetBytes(message);
        NetworkStream stream = client.GetStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.WriteLine(message);
        writer.Flush();
        
    }
