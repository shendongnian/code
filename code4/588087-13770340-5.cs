    public string GetRawName(string file)
    {
        string name = Path.GetFileNameWithoutExtension(file);
        return Regex.Replace(name, @"(_\d+)?$", "")
    }
