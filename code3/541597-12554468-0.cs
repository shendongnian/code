    class Filter
    {
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
        public bool Matches(Marble m)
        {
            var T = typeof(Marble);
            var prop = T.GetProperty(PropertyName);
            var value = prop.GetValue(m);
            return value.Equals(PropertyValue);
        }
    }
