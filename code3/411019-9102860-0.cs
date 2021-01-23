    class MyClass : IEnumerable<int>
    {
        public void Add(int value) { ... }
        public IEnumerator<int> GetEnumerator() { ... }
        IEnumerator IEnumerable.GetEnumerator() { ... }
    }
