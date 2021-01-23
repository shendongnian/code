    private Dictionary<string, string> keys = new Dictionary<string, string>();
    public void add(string key, string value)
    {
        this.keys.Add(key, value);
    }
    public string get(string key)
    {
        return this.keys[key];
    }
