    List<Dictionary<string, string>> entries = new List<Dictionary<string, string>>();
    Dictionary<string, string> entry = null;
    foreach (string line in File.ReadAllLines(logFilePath))
    {
        string[] fields = line.Split('=');
        if (fields.Length > 1)
        {
            if (fields[0].Trim() == "id")
            {
                if (entry != null) entries.Add(entry);
                entry = new Dictionary<string, string>();
            }
            if (entry != null) entry[fields[0].Trim()] = fields[1].Trim();
        }
    }
    if (entry != null) entries.Add(entry);
