    using (var client = new WebClient())
    using (var stream = client.OpenRead("http://..."))
    using (var file = File.OpenWrite("C:\\..."))
    {
        var buffer = new byte[512];
        int bytesReceived;
        while ((bytesReceived = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            stream.Write(buffer, 0, bytesReceived);
        }
    }
