    class A : IEnumerable
    {
        int[] data = { 0, 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
