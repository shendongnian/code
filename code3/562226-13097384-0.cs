    string SendCmd(string cmd, string ip, int port)
    {
        var client = new TcpClient(ip, port);
        var data = Encoding.GetEncoding(1252).GetBytes(cmd);
        var stm = client.GetStream();
        stm.Write(data, 0, data.Length);
        byte[] resp = new byte[2048];
        var memStream = new MemoryStream();
        int bytes = 0;
        do
        {
            bytes = 0;
            while (!stm.DataAvailable)
                Thread.Sleep(20); // some delay
            bytes = stm.Read(resp, 0, resp.Length);
            memStream.Write(resp, 0, bytes);
        } 
        while (bytes > 0);
        return Encoding.GetEncoding(1252).GetString(memStream.ToArray());
    }
