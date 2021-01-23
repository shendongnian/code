    class ResultMap
    {
        public void Add(int[] key, string value)
        {
            Debug.Assert(key != null);
            Debug.Assert(key.Length > 0);
            
            var currentMap = _root;
            foreach (var i in key.Take(key.Length - 1))
            {
                object levelValue;
                if (currentMap.TryGetValue(i, out levelValue))
                {
                    currentMap = levelValue as Dictionary<int, object>;
                    if (currentMap == null)
                        throw new Exception("A rule is already defined for this key.");
                }
                else
                {
                    var newMap = new Dictionary<int, object>();
                    currentMap.Add(i, newMap);
                    currentMap = newMap;
                }
            }
            var leaf = key[key.Length - 1];
            if (currentMap.ContainsKey(leaf))
                throw new Exception("A rule is already defined for this key.");
            currentMap.Add(leaf, value);
        }
        public string TryGetValue(params int[] key)
        {
            Debug.Assert(key != null);
            Debug.Assert(key.Length > 0);
            var currentMap = _root;
            foreach (var i in key)
            {
                object levelValue;
                if (!currentMap.TryGetValue(i, out levelValue))
                    return null;
                currentMap = levelValue as Dictionary<int, object>;
                if (currentMap == null)
                    return (string) levelValue;
            }
            return null;
        }
        private readonly Dictionary<int, object> _root = new Dictionary<int, object>();
    }
