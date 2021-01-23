    public static string GetValueAndRemove<TKey, TValue>(this Dictionary<int, string> dict, int key)
    {
        string val = dict[key];
        dict.Remove(key);
        return val;    
    }
    
    static void Main(string[] args)
    {
        Dictionary<int, string> a = new Dictionary<int, string>();
        a.Add(1, "sdfg");
        a.Add(2, "sdsdfgadfhfg");
        string value = a.GetValueAndRemove<int, string>(1);
    }
