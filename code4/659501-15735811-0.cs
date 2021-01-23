    IEnumerable<string> ReadRequestHeaders(Socket s)
    {
        using (var stream = new NetworkStream(s, false))
        using (var reader = new StreamReader(stream))
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == "")
                    break;
                yield return line;
            }
        }
    }
