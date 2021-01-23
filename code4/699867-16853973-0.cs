    public static Dictionary<string, int> CountOccurences(ArrayList items) 
    {
        var dict = new Dictionary<string, int>();
        foreach(object t in items)
        {
            string key = "";
            if(t != null)
                key = t.ToString();
            int count;
            dict.TryGetValue(key, out count);
            dict[key] = count++;
        }
        return dict;
    }
