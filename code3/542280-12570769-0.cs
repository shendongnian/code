    public static class DictionaryHelper
    {
        
        public static void Add(this Dictionary<Tuple<int,int>, List<string>> dict,Tuple<int,int> key, string value)
        {
            if(dict.ContainsKey(key))
            {
                dict[key].Add(value);
            }
            else
            {
                dict.Add(key, new List<string>{value});
            }
        } 
    }
