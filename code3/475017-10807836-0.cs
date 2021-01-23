    nt port = 12345;
                IPAddress serverAddress = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(serverAddress, port);
                listener.Start();
    
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
    
                    NetworkStream stream = client.GetStream();
                    byte[] data = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(data, 0, Convert.ToInt32(client.ReceiveBufferSize));
                    string request = Encoding.ASCII.GetString(data, 0, bytesRead);
                    Console.WriteLine(request);
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes("200 OK");
    
                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    client.Close();
                }
