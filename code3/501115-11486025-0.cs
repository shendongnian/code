    List<string> parts = new List<string>();
    foreach(string separator in consonants)
    {
        parts.Add(line.Split(separator));
    }
    parts = parts.Distinct().ToList();
