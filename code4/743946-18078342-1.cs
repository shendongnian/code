    class Program
    {
        static void Main(string[] args)
        {
            var rD = new RingDictionary(50);
            for (int i = 0; i < 75; i++)
            {
                rD.Add(i, i);
            }
            foreach (var item in rD.Keys)
            {
                Console.WriteLine("{0} {1}", item, rD[item]);
            }
        }
    }
    class RingDictionary : OrderedDictionary
    {
        int indexKey;
        int _capacity = 0;
        public int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Value must be positive.");
                _capacity = value;
            }
        }
        public RingDictionary(int capacity)
        {
            indexKey = -1;
            Capacity = capacity;
        }
        public new void Add(object key, object value)
        {
            indexKey++;
            if (base.Keys.Count == _capacity)
            {
                base.RemoveAt(indexKey % _capacity);
                base.Insert(indexKey % _capacity, key, value);
            }
            else
            {
                base.Add(key, value);
            }
        }
    }
