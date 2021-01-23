    public class MyClass
    {
        public string Name { get; set; }
    }
    // Feel free to get rid of where TValue : class, I just wanted to add a return null for values not found. Handle this however you like / exception whatever.
    public class MyClassDictionary<TValue> : Dictionary<MyClass, TValue> where TValue : class
    {
        public TValue this[string val]
        {
            get
            {
                if (Keys.Any(x => x.Name == val))
                    return base[Keys.First(x => x.Name == val)];
                return null;
            }
        }
    }
