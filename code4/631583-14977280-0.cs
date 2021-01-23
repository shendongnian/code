    class foo: IComparable<foo>
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public int counter { get; set; }
        public int Compare(foo x, foo y)
        {
            if (x == null || y == null) return int.MinValue;
            if (x.name != y.name)
                return StringComparer.CurrentCulture.Compare(x.name, y.name);
            else if (x.date != y.date)
                return x.date.CompareTo(y.date);
            else if (x.counter != y.counter)
                return x.counter.CompareTo(y.counter);
            else
                return 0;
        }
        public int CompareTo(foo other)
        {
            return Compare(this, other);
        }
    }
