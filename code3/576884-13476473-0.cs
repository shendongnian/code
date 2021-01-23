    void start_listening()
    {
        TcpListener listen = new TcpListener(IPAddress.Any, port_increment);
        garabage_collection_preventor.Add(listen);
        listen.Start();
        while (true)
        {
            TcpClient client = listen.AcceptTcpClient();
            // etc
        }
    }
