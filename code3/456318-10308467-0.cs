<!-- -->
    public static class PropertyAdapter
    {
        public static PropertyAdapter<T> Create<T>(T obj)
        {
            return new PropertyAdapter<T>(obj);
        }
    }
    public class PropertyAdapter<T> : IEnumerable<string>
    {
        private T obj;
        public PropertyAdapter(T obj) { this.obj = obj; }
        public override string ToString()
        {
            return obj.ToString();
        }
        public object this[string name]
        {
            get
            {
                return typeof(T).GetProperty(name).GetValue(obj, null);
            }
        }
        public IEnumerator<string> GetEnumerator()
        {
            return typeof(T)
                .GetProperties()
                .Select(pi => pi.Name)
                .GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
