    using (var sr = new StreamReader("test.log"))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            if (line.IndexOf("INFO", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // line contains "info"
            }
        }
    }
