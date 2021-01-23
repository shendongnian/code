    public static class Client
    {
        public static void Run(int port, string dataToSend)
        {
            using (var client= new TcpClient("localhost", port))
            {
                using (var stream = client.GetStream())
                {
                    var buffer = Encoding.UTF8.GetBytes(dataToSend);
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
