    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> _sessionDictionary = new Dictionary<string, object>();
        public override object this[string name]
        {
            get
            {
                return _sessionDictionary.ContainsKey(name) ? _sessionDictionary[name] : null;
            }
            set
            {
                _sessionDictionary[name] = value;
            }
        }
        public override void Abandon()
        {
            var keys = new List<string>();
            foreach (var kvp in _sessionDictionary)
            {
                keys.Add(kvp.Key);
            }
            foreach (var key in keys)
            {
                _sessionDictionary.Remove(key);
            }
        }
        public override void Clear()
        {
            var keys = new List<string>();
            foreach (var kvp in _sessionDictionary)
            {
                keys.Add(kvp.Key);
            }
            foreach(var key in keys)
            {
                _sessionDictionary.Remove(key);
            }
        }
    }
