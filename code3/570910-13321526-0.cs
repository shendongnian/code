    class PropertyMap
    {
        private Dictionary<string, string> map = new Dictionary<string, string>();
        public string add(string key, string value) { map.Add(key, value); }
        public string @get(string key) { return map[key]; }
        public string this[string key]  //  <-- indexer allows you to access by string
        {
            get
            {
                return @get(key);
            }
            set
            {
                add(key, value);
            }
        }
    }
