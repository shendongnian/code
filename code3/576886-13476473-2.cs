    void start_listening()
    {
        while (true)
        {
            TcpListener listen = new TcpListener(IPAddress.Any, port_increment);
            garabage_collection_preventor.Add(listen);
            listen.Start();
            while (true)
            {
                TcpClient client = listen.AcceptTcpClient();
                IPEndPoint temp_end = ((IPEndPoint)listen.LocalEndpoint);
                address_dictionary.Add(temp_end, false);
                new Thread(new ParameterizedThreadStart(connection_stuff)).Start(client);
            }
            port_increment++;
        }
    }
