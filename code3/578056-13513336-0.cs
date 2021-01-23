    public Dictionary<string, string> MyField { get; set; }
    public string this[string key]
    {
        get
        {
            string result;
            if (MyField.TryGetValue(key, out result))
            {
                return result;
            }
    
            return string.Empty;
        }
    }
