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
                {
                    var errorMessage = typeof(Environment)
                        .GetMethod(
                            "GetResourceString",
                            System.Reflection.BindingFlags.Static |
                            System.Reflection.BindingFlags.NonPublic,
                            null,
                            new Type[] { typeof(string) },
                            null)
                        .Invoke(null, new object[] { 
                            "ArgumentOutOfRange_NegativeCapacity" 
                        }).ToString();
                    throw new ArgumentException(errorMessage);
                }
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
            if (base.Keys.Count > _capacity)
            {
                for (int i = base.Keys.Count-1; i >Capacity-1 ; i--)
                {
                    base.RemoveAt(i);
                }
            }
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
