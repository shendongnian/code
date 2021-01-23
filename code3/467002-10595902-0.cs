    public static Dictionary<string, string> ToDictionary(string value, char pairSeperator, char valueSeperator) 
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (string pair in value.Split(pairSeperator))
        {
            string[] keyValue = pair.Split(valueSeperator);
            dictionary.Add(keyValue[0], keyValue[1]);
        }
        
        return dictionary;
    }
