    class A : IEnumerable<int>
    {
        int[] data = { 0, 1, 2, 3, 4 };
        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)data).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
