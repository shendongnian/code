    public class Default
    {
        private Dictionary<int, DayOfWeek> _values = new Dictionary<int,DayOfWeek>();
        public DayOfWeek this[int index]
        {
            get
            {
                if (_values.ContainsKey(index))
                    return _values[index];
                else
                    return null;
            }
            set
            {
                _values[index] = value;
            }
        }
    }
