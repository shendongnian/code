    public class Location
    {
        public string Origin { get; set; }
        public string Dest { get; set; }
        public bool Equals(Location other)
        {
            //...
        }
        public override bool Equals(object obj)
        {
            //...
        }
        public override int GetHashCode()
        {
            //...
        }
    }
    public class LocationMatrix
    {
        private readonly HashSet<string> _origins = new HashSet<string>();
        private readonly HashSet<string> _dests = new HashSet<string>();
        private readonly Dictionary<Location, int> _values = new Dictionary<Location, int>();
        public int this[Location location]
        {
            get
            {
                if (!_values.ContainsKey(location))
                {
                    SetValue(location, 0);
                }
                return _values[location];
            }
            set { SetValue(location, value); }
        }
        private void SetValue(Location location, int value)
        {
            if (!_origins.Contains(location.Origin))
                _origins.Add(location.Origin);
            if (!_dests.Contains(location.Dest))
                _dests.Add(location.Dest);
            _values[location] = value;
        }
        public int this[string origin, string dest]
        {
            get { return this[new Location {Origin = origin, Dest = dest}]; }
            set { this[new Location {Origin = origin, Dest = dest}] = value; }
        }
        public override string ToString()
        {
            var content = new StringBuilder();
            //print dest lables
            content.AppendLine(_dests.Aggregate((x, y) => x + ", " + y));
            foreach (string origin in _origins)
            {
                //print origin lable
                content.Append(origin + ", ");
                foreach (string dest in _dests)
                {
                    content.Append(this[origin, dest] + ", ");
                }
                content.Remove(content.Length - 2, 2);
                content.AppendLine();
            }
            return content.ToString();
        }
    }
