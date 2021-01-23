    using (var client = new TcpClient())
    {
        client.Connect(host, porg);
        using (var stream = client.GetStream())
        {
            // Or some other encoding, of course...
            byte[] data = Encoding.UTF8.GetBytes(xmlString);
            stream.Write(data, 0, data.Length);
            // Whatever else you want to do...
        }
    }
