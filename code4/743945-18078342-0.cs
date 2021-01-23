    class Program
    {
        static void Main(string[] args)
        {
            var rD = new RingDictionary(50);
            for (int i = 0; i < 100; i++)
            {
                rD.Add(i, i);
            }
            foreach (var item in rD.Keys)
            {
                Console.WriteLine("{0} {1}", item,rD[item]);
            }
        }
    }
    class RingDictionary : OrderedDictionary
    {
        int indexKey;
        int _capacity = 0;
        public RingDictionary(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Value must be positive.");
            indexKey = -1;
            _capacity = capacity;
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
