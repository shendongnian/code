    public class MyModel
    {
        private readonly IList<string> _values = new List<string>();
        public void Add(string value)
        {
            _values.Add(value);
        }
        public string ValuesToString()
        {
            return string.Join(",", _values);
        }
    }
