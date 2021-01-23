    class Program
    {
        public static SortedDictionary<string, int> MyCache = new SortedDictionary<string, int>();
        static void Main(string[] args)
        {
            AddToDictionary("Result1");
            AddToDictionary("Result1");
            AddToDictionary("Result2");
            AddToDictionary("Result2");
            AddToDictionary("Result2");
            AddToDictionary("Result3");
            List<KeyValuePair<string, int>> list = MyCache.ToList();
            foreach (var item in list.OrderByDescending(r=> r.Value))
            {
                Console.WriteLine(item.Key+ " - hits " + item.Value);
            } 
            
        }
        public static void AddToDictionary(string strKey)
        {
            if (MyCache.ContainsKey(strKey))
            {
                MyCache[strKey] = MyCache[strKey] + 1;
            }
            else
            {
                MyCache.Add(strKey, 1);
            }
        }
    }
