    class MyClass
    {
        private List<object> _items = new List<object>();
        public void Add(int value) { _items.Add(value); }
        public void Add(Class1 value) { _items.Add(value); }
    }
