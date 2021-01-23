    private Dictionary<string, string> users = new Dictionary<string, string>();
    public void Set(string key, string value)
    {
        if (users.ContainsKey(key))
        {
            users[key] = value;
        }
        else
        {
            users.Add(key, value);
        }
    }
    public string Get(string key)
    {
        string result = null;
        if (users.ContainsKey(key))
        {
            result = users[key];
        }
        return result;
    }
