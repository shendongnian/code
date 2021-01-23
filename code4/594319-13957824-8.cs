    public static class Client
    {
        public static void Run(string hostname, int port, string dataToSend, Action<string> replyCallback)
        {
            using (var client = new TcpClient(hostname, port))
            {
                using (var stream = client.GetStream())
                {
                    var buffer = Encoding.UTF8.GetBytes(dataToSend);
                    stream.Write(buffer, 0, buffer.Length);
                    // Shutdown the send side of the socket, indicating to the server we're done sending our message
                    client.Client.Shutdown(SocketShutdown.Send);
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.ReadTimeout = 1000; // 1 second timeout
                        int bytesRead;
                        // Loop until Read returns 0, signalling the socket has been closed
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            memoryStream.Write(buffer, 0, bytesRead);
                        }
                        replyCallback(Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
                    }
                }
            }
        }
    }
