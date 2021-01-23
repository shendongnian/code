    public class MyViewModel()
    {
        private readonly List<string> _values = new List<string>();
        public string[] Values { get { return _values.ToArray(); } }
        public void AddValue(string value)
        {
            _values.Add(value);
        }
    }
