    public class Container
    {
        private Dictionary<string, Action<string>> handlers = 
                new Dictionary<string, Action<string>>();
    
        public void CreateEventForKey(string key)
        {
            // with empty handler added you can avoid null check
            handlers.Add(key, (value) => { });
        }
    
        public void OnEventForKey(string key, string value)
        {
            if (!handlers.ContainsKey(key))
                throw new Exception();
    
            handlers[key](value);
        }
    
        public void Subscribe(string key, Action<string> handler)
        {
            if (!handlers.ContainsKey(key))
                throw new Exception();
    
            handlers[key] += handler;
        }
    }
