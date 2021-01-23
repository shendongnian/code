    static void Main(string[] args)
    {
        var client = new TcpClient("...", ...);
        var buffer = new byte[1024];
        using (var networkStream = client.GetStream())
        {
            int bytesRead;
            while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                var hexString = BitConverter.ToString(buffer, 0, bytesRead);
                Console.WriteLine("Bytes received: {0}", hexString);
            }
        }
    }
