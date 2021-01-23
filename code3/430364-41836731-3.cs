    class TestSession : ISession
    {
        public TestSession()
        {
            Values = new Dictionary<string, byte[]>();
        }
        public string Id
        {
            get
            {
                return "session_id";
            }
        }
        public bool IsAvailable
        {
            get
            {
                return true;
            }
        }
        public IEnumerable<string> Keys
        {
            get { return Values.Keys; }
        }
        public Dictionary<string, byte[]> Values { get; set; }
        public void Clear()
        {
            Values.Clear();
        }
        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }
        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }
        public void Remove(string key)
        {
            Values.Remove(key);
        }
        public void Set(string key, byte[] value)
        {
            if (Values.ContainsKey(key))
            {
                Remove(key);
            }
            Values.Add(key, value);
        }
        public bool TryGetValue(string key, out byte[] value)
        {
            if (Values.ContainsKey(key))
            {
                value = Values[key];
                return true;
            }
            value = new byte[0];
            return false;
        }
    }
