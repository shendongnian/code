    public class ObjectContainer
    {
        private Dictionary<string, object> cache;
    
        public ObjectContainer()
        {
            cache = new Dictionary<string, object>();
        }
        public T Fetch<T>(string name)
        {
            object value;
            cache.TryGetValue(name, out value);
            return (T)value;
        }
        public void Add(string name, object value)
        {
            cache.Add(name, value);
        }
    }
    ...
    var cache = new ObjectContainer();
    cache.Add("data1", 12345);
    cache.Add("data2", new ClassName());
    var intData = cache.Fetch<int>("data1");
    var objData = cache.Fetch<ClassName>("data2");
