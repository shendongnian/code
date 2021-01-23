    var paneContent = new StringBuilder();
    bool lineFound = false;
    foreach (string line in File.ReadLines(path))
    {
        if (line.Contains(tag))
        {
            lineFound = !lineFound;
        }
        else
        {
            if (lineFound)
            {
                paneContent.Append(line);
            }
        }
    }
    using (TextReader reader = new StringReader(paneContent.ToString()))
    {
        data = (PaneData)(serializer.Deserialize(reader));
    }
