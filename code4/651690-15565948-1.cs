    using (TcpClient client = listener.AcceptTcpClient())
    using (NetworkStream stream = client.GetStream())
    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
    using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        string line = string.Empty;
        while ((line = sr.ReadLine()) != string.Empty)
        {
            string[] tokens = line.Split(new char[] { ':' }, 2);
            if (!string.IsNullOrWhiteSpace(line) && tokens.Length > 1)
            {
                headers[tokens[0]] = tokens[1].Trim();
            }
        }
        string responseKey = "";
        string key = string.Concat(headers["Sec-WebSocket-Key"], "258EAFA5-E914-47DA-95CA-C5AB0DC85B11");
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(key));
            responseKey = Convert.ToBase64String(hash);
        }
        sw.WriteLine("HTTP/1.1 101 Switching Protocols");
        sw.WriteLine("Upgrade: websocket");
        sw.WriteLine("Connection: Upgrade");
        sw.WriteLine("Sec-WebSocket-Accept: " + responseKey);
        sw.WriteLine("Sec-WebSocket-Protocol: chat");
        sw.WriteLine("");
        sw.Flush();
    }
 
