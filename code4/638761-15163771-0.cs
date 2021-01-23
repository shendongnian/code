    memoryStream.Position = 0; // Rewind!
    List<string> rows = new List<string>();
    // Are you *sure* you want ASCII?
    using (var reader = new StreamReader(memoryStream, Encoding.ASCII))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            rows.Add(line);
        }
    }
