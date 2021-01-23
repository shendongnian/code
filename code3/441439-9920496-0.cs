    class MyClass
    {
        Dictionary<string, object> _values = new Dictionary<string, object>();
    
        public object this[string name]
        {
            get
            {
                if (!_values.ContainsKey(name))
                    throw new ArgumentException(name);
    
                return _values[name];
            }
    
            set
            {
                if (!_values.ContainsKey(name))
                {
                    _values.Add(name, value);
                    return;
                }
    
                _values[name] = value;
            }
        }
    }
