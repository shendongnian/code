    string line = reader.ReadLine();
    while (line != null)
    {
        if (!String.IsNullOrEmpty(line) && !line.StartsWith("//"))
        {
            count++;
        }
        line = reader.ReadLine();
    }
