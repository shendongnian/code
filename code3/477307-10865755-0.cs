    NetworkStream stream = _connection.GetStream();
    StreamReader input = new StreamReader(stream);
    _output = new StreamWriter(stream);
    string line;
    do
    {
        // Poll for data availability.
        while (!stream.DataAvailable)
            Thread.Sleep(300);
        line = input.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
            ParseMessage(line);
        }
    }
    while (line != null);
    line = input.ReadLine();
