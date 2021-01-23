    public sealed class ArrayRope<T>
    {
        private readonly T[][] map;
        private readonly int blockSize;
        private readonly int noOfBlocks;
        public ArrayRope(int blockSize, int noOfBlocks)
        {
            ...
        }
        public T this[int index]
        {
            get
            {
                int ropeIndex = index / blockSize;
                int offset = index % blockSize;
                return map[ropeIndex][offset];
            }
            set
            {
                int ropeIndex = index / blockSize;
                int offset = index % blockSize;
                map[ropeIndex][offset] = value;
            }
        }
        ...
    }
