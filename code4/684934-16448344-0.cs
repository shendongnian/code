    static class DailyStats
    {
        static Dictionary<int, Dictionary<string, string>> _dic;
    
        static DailyStats()
        {
            _dic = new Dictionary<int, Dictionary<string, string>>();
        }
    
        public static void Add(int i, string key, string value)
        {
            if (!_dic.ContainsKey(i))
                _dic[i] = new Dictionary<string, string>();
            _dic[i][key] = value;
        }
    
        public static string Get(int i, string key)
        {
            if (!_dic.ContainsKey(i) || !_dic[i].ContainsKey(key))
                return null;
            return _dic[i][key];
        }
    }
        DailyStats.Add(1, "Stats", "a");
        Console.WriteLine(DailyStats.Get(1, "Stats"));
