    class A : IEnumerable
    {
        int[] data = { 0, 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            for (int i=0;i<data.Length;++i)
               yield return data[i];
        }
    }
