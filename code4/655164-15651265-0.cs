    public class StringObjectList : IList<string>
    {
        private List<object> _list;
        public StringObjectList(List<object> src)
        {
            _list = src;
        }
        // IList Implementation...
        
        public string this[int index]
        {
            get
            {
                object obj = _list[index];
                if (obj == null)
                    return null;
                return obj.ToString();
            }
            set
            {
                _list[index] = value;
            }
        }
        // ... plus 3 more IList<string> methods (IndexOf, Insert, RemoveAt)
        // ICollection<string> implementation (5 methods, 2 properties)
        // IEnumerable<string> implementation (1 method)
        // IEnumerable implementation (1 method)
    }
