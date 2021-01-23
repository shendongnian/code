    public static string GetValue(Dictionary<int, string> dictionary, int key)
    {
        string output;
        if (dictionary.TryGetValue(key, out output))
            return output;
        else
            return "";
    }
    
    public static string GetValue(List<Thing> list, int index)
    {
        if (index < list.Count)
            return list[index].Stuff;
        else
            return "";
    }
