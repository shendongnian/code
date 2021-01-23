    class MyValue {
        public Type Type { get; private set; }
        private MyValue(Type type)
        {
            this.Type = type;
        }
        public MyValue of<T>() where T : BaseClass
        {
            return new MyValue(typeof(T));
        }
    }
    IDictionary<int, MyValue> myDictionary = new Dictionary<int, MyValue>()
    {
        { 1, MyValue.of<SubClass1>(); },
        { 2, MyValue.of<SubClass2>(); },
        { 3, MyValue.of<NotSubClass>(); }, // this causes a compile error
    };
