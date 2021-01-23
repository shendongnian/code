    public class SessionState
    {
        private Dictionary<string, int> Cache { get; set; }
    
        public SessionState()
        {
            this.Cache = new Dictionary<string, int>();
        }
    
        public void SetCachedValue(string key, int val)
        {
            if (!this.Cache.ContainsKey(key))
            {
                this.Cache.Add(key, val);
            }
            else
            {
                this.Cache[key] = val;
            }
        }
    
        public int GetCachedValue(string key)
        {
            if (!this.Cache.ContainsKey(key))
            {
                return -1;
            }
    
            return this.Cache[key];
        }
    }
    
    public class Service1
    {
        private static sessionState = new SessionState();
    
        public void Method1(string privateKey)
        {
            sessionState.SetCachedValue(privateKey, {some integer value});
        }
    
        public int Method2(string privateKey)
        {
            return sessionState.GetCachedValue(privateKey);
        }
    }
