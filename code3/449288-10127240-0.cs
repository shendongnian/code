    Dictionary<int, Dictionary<string, string>> lines = new Dictionary<int, Dictionary<string, string>>();
    while ((line = sr.ReadLine()) != null)
    {
        Dictionary<string, string> f = new Dictionary<string, string>();
        lineArr = line.Split(',');
        int x = 0;
        foreach (string field in lineArr)
        {
            f.Add(keys[x], field);
            x++;
        }
        lines.Add(lineIndex, f);
        lineIndex++;
