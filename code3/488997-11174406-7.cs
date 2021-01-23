    // Don't do this in production code!
    class CrazyAdd : IEnumerable
    {
        public void Add(int x, int y, int z)
        {
            Console.WriteLine(x + y + z); // Well it *does* add...
        }
        public IEnumerator GetEnumerator() { throw new NotImplementedException(); }
    }
