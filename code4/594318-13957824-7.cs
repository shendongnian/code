    public static class Server
    {
        public static void Run(int port, Action<string> callback)
        {
            var listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();
            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                {
                    try
                    {
                        var buffer = new byte[2048];
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var stream = client.GetStream())
                            {
                                stream.ReadTimeout = 1000; // 1 second timeout
                                int bytesRead;
                                // Loop until Read returns 0, signalling the socket has been closed
                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    memoryStream.Write(buffer, 0, bytesRead);
                                }
                            }
                            // Pass the client's message to the callback and use the response as the reply message to the client.
                            var reply = Encoding.UTF8.GetBytes(callback(Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length)));
                            stream.Write(reply, 0, reply.Length);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                }
            }
        }
    }
