    public static void DownloadFile(Uri address, string filePath)
    {
        using (var client = new WebClient())
        using (var stream = client.OpenRead(address))
        using (var file = File.Create(filePath))
        {
            var buffer = new byte[4096];
            int bytesReceived;
            while ((bytesReceived = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                file.Write(buffer, 0, bytesReceived);
            }
        }
    }
