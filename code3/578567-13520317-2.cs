    var listener = new TcpListener(IPAddress.Loopback, 8181);
    listener.Start();
    while (true)
    {
        Console.WriteLine("Listening...");
        using (var client = listener.AcceptTcpClient())
        using (var stream = client.GetStream())
        using (var reader = new StreamReader(stream))
        using (var writer = new StreamWriter(stream))
        {
            string line = null, key = "", responseKey = "";
            string MAGIC_STRING = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
            while (line != "")
            {
                line = reader.ReadLine();
                if (line.StartsWith("Sec-WebSocket-Key:"))
                {
                    key = line.Split(':')[1].Trim();
                }
            }
            if (key != "")
            {
                key += MAGIC_STRING;
                using (var sha1 = SHA1.Create())
                {
                    responseKey = Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(key)));
                }
            }
            // send handshake to the client
            writer.WriteLine("HTTP/1.1 101 Web Socket Protocol Handshake");
            writer.WriteLine("Upgrade: WebSocket");
            writer.WriteLine("Connection: Upgrade");
            writer.WriteLine("WebSocket-Origin: http://127.0.0.1");
            writer.WriteLine("WebSocket-Location: ws://localhost:8181/websession");
            if (!String.IsNullOrEmpty(responseKey)) 
                writer.WriteLine("Sec-WebSocket-Accept: " + responseKey);
            writer.WriteLine("");
            writer.Flush();
            SendString(stream, "This code works!!!!");
            SendString(stream, "This code also works!!!! ".PadRight(300, '.') + "\r\nEND");
        }
        Console.WriteLine("Finished");
    }
    void SendString(Stream s, string str)
    {
        var buf = Encoding.UTF8.GetBytes(str);
        int frameSize = 64;
        var parts = buf.Select((b, i) => new { b, i }).GroupBy(x => x.i / (frameSize - 1))
                                .Select(x => x.Select(y => y.b).ToArray())
                                .ToList();
        for (int i = 0; i < parts.Count; i++ )
        {
            byte cmd = 1;
            if (i != 0) cmd = 0;
            if (i == parts.Count - 1) cmd = 0x80;
            if (parts.Count == 1) cmd = 0x81;
                    
            s.Write(new byte[] { cmd }, 0, 1);
            s.Write(new byte[] { (byte)parts[i].Length }, 0, 1);
            s.Write(parts[i], 0, parts[i].Length);
        }
            
        s.Flush();
    }
