    // Don't do this in production code!
    class Crazy : IEnumerable<int>
    {
        public void Add(int x, int y, int z)
        {
            Console.WriteLine(x + y + z); // Well it *does* add...
        }
        public IEnumerator<int> GetEnumerator() { throw new NotImplementedException(); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    }
