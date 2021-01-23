    TcpListener listener = new TcpListener(IPAddress.Any, 3128);
    listener.Start();
    while (true)
    {
        var client = listener.AcceptTcpClient();
        new Thread(() =>
        {
            using (Stream s = client.GetStream())
            {
                var reader = new StreamReader(s);
                var writer = new StreamWriter(s);
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
