    public Dictionary<string, string> Dict = new Dictionary<string, string>();
    foreach (string optionKey in i.options.Keys)
    {
       string optionValue = i.options.Values.ToString();
       if(!Dict.ContainsValue(optionValue))
           Dict.Add(optionValue, optionKey);
    }
