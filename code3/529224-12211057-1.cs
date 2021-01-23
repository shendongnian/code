    public class MyDynamicObject : DynamicObject, IDictionary<string, object>
    {
        public Dictionary<string, object> members = new Dictionary<string, object>();
        
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return members.GetEnumerator();
        }
        
        public void Add(KeyValuePair<string, object> item)
        {
            members.Add(item.Key, item.Value);
        }
        // ...
    }
