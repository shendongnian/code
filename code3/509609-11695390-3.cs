    class RangeMap<T>
    {
        private SortedList<float, T>  _values;
        public RangeMap()
        {
            _values = new SortedList<float, T>();
        }
    
        public void AddPoint(float max, T value)
        {
            _values[max] = value;
        }
    
        public T GetValue(float point)
        {
            if (_values.ContainsKey(point)) return _values[point];
    
            return (from kvp in _values where kvp.Key > point select kvp.Value)
                   .FirstOrDefault();
        }
    }	
