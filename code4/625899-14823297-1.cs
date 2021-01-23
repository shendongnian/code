    public class MyClass
    {
        public string Name { get; set; }
        // You may want to implement equality members on your class so that 
        // the dictionary treats the Name value as the key correctly.
    }
    public class MyClassDictionary<TValue> : Dictionary<MyClass, TValue>
    {
        public TValue this[string val]
        {
            get
            {
                return base[Keys.First(x => x.Name == val)];
            }
        }
    }
