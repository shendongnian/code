    class Foo : IEnumerable<int>
    {
        public void Add(int x, int y, int z)
        {
            Debug.WriteLine(x + y + z);
        }
        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
