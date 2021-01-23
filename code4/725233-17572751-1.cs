    public Dictionary<string, string> GetSettings()
    {
        return new [] { keyA, keyB }.Where(x => Settings.ContainsKey(x))
                                    .ToDictionary(x => x, Settings[x]);
    }
