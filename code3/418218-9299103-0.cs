    List<string> items = new List<string>(new string[] { "1:2", "5:90", "7:12", "1:70", "29:60" });
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    
    foreach (string item in items)
    {
        string[] data = item.Split(':');
        string key = data[0];
    
        if (!dictionary.ContainsKey(data[0]))
        {
            int value = dictionary[data[0]];
            dictionary[key] += int.Parse(data[1]);
        }
    }
    
    //Used dictionary values here
