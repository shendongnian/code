    class TheSimpleListManager
    {
        private Dictionary<String, List<Int32>> Lists = new Dictionary<String, List<Int32>>();
        public void AddList(String key, List<Int32> list)
        {
           if(!Lists.ContainsKey(key))
           {
               Lists.Add(key, list);
           }
           else
           {
              // list already exists....
           }
        }
    }
