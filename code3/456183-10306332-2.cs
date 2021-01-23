    Thread t = new Thread(Server);
    t.IsBackground = true;
    t.Start();
-
    void Server()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 3128);
        listener.Start();
        while (true)
        {
            var client = listener.AcceptTcpClient();
            new Thread(() =>
            {
                using (client)
                {
                    var reader = new StreamReader(client.GetStream());
                    var writer = new StreamWriter(client.GetStream());
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == "QUIT") break;
                        writer.WriteLine("From server > " + line);
                        writer.Flush();
                    }
                }
            }).Start();
        }
    }
